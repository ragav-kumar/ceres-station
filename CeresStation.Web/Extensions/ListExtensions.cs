using System.Collections;
using System.Reflection;
using CeresStation.Core;
using CeresStation.Dto;
using CeresStation.Model;
using Microsoft.EntityFrameworkCore;
using Column = CeresStation.Model.Column;
using EntityType = CeresStation.Model.EntityType;

namespace CeresStation.Web;

internal static class ListExtensions
{
    internal static void ApplyDtos(this StationContext ctx, EntityType entityType, IList<ColumnDto> dtos)
    {
        HashSet<ColumnDto> dtoSet = dtos.ToHashSet();
        HashSet<Column> modelSet = ctx.Columns.Where(o => o.EntityType == entityType).ToHashSet();

        // Delete
        List<Column> toDelete = modelSet
            .Where(o => dtoSet.All(d => d.Id != o.Id))
            .ToList();
        ctx.Columns.RemoveRange(toDelete);

        // Add
        List<Column> toAdd = dtoSet
            .Where(o => modelSet.All(m => m.Id != o.Id))
            .ToModel()
            .ToList();
        ctx.Columns.AddRange(toAdd);

        // Update
        List<ColumnDto> toUpdate = dtoSet
            .Where(o => modelSet.Any(m => m.Id == o.Id))
            .ToList();
        foreach (ColumnDto dto in toUpdate)
        {
            Column model = modelSet.Single(m => m.Id == dto.Id);
            ApplyDto(model, dto);
        }
    }

    private static void ApplyDto(this Column model, ColumnDto dto)
    {
        if (dto.EntityType is not null)
            model.EntityType = dto.EntityType.Value;
        if (dto.DisplayName is not null)
            model.DisplayName = dto.DisplayName;
        if (dto.Width is not null)
            model.Width = dto.Width.Value;
        if (dto.Order is not null)
            model.Order = dto.Order.Value;

        if (dto.AttributeDefinitionId is not null)
        {
            model.FieldType = FieldType.Attribute;
            model.AttributeDefinitionId = dto.AttributeDefinitionId;
            model.FieldName = null;
        }
        else if (dto.FieldName is not null)
        {
            model.FieldType = FieldType.Model;
            model.AttributeDefinitionId = null;
            model.FieldName = dto.FieldName;
        }
        else
        {
            throw new InvalidOperationException("Every column must reference either a field or an attribute.");
        }
    }

    private static IEnumerable<Column> ToModel(this IEnumerable<ColumnDto> dtos) => dtos.Select(ToModel);

    private static Column ToModel(this ColumnDto dto) => new()
    {
        Id = Guid.NewGuid(),
        EntityType = dto.EntityType ?? EntityType.Undefined,
        Order = dto.Order ?? 0,
        FieldName = dto.FieldName,
        FieldType = dto.FieldName is not null ? FieldType.Model : dto.AttributeDefinitionId is not null ? FieldType.Attribute : FieldType.Undefined,
        Width = dto.Width ?? 100,
        DisplayName = dto.DisplayName,
        AttributeDefinitionId = dto.AttributeDefinitionId
    };

    private static ColumnDto ToDto(this Column model) => new(
        Id: model.Id,
        EntityType: model.EntityType,
        Order: model.Order,
        DisplayName: model.DisplayName,
        AttributeDefinitionId: model.AttributeDefinitionId,
        FieldName: model.FieldName,
        Width: model.Width
    );
    
    internal static IEnumerable<ColumnDto> ToDto(this IEnumerable<Column> models) => models.Select(ToDto);

    internal static EntityType ToEntityType(string entityTypeName)
    {
        return entityTypeName.ToLower() switch
        {
            "extractor" or "extractors" => EntityType.Extractor,
            "processor" or "processors" => EntityType.Processor,
            "transport" or "transports" => EntityType.Transport,
            "consumer" or "consumers" => EntityType.Consumer,
            _ => throw new ArgumentException($"Unknown entity type: {entityTypeName}")
        };
    }

    internal static string ToTableName(string entityTypeName)
    {
        return entityTypeName.ToLower() switch
        {
            "extractor" or "extractors" => "Extractor",
            "processor" or "processors" => "Processor",
            "transport" or "transports" => "Transport",
            "consumer" or "consumers" => "Consumer",
            _ => throw new ArgumentException($"Unknown entity type: {entityTypeName}")
        };
    }

    internal static object? ToDto(this PropertyInfo property, object obj) => MapValue(property.GetValue(obj));
    
    private static object? MapValue(object? value) => value switch
    {
        EntityBase entityBase  => entityBase.ToDto(),
        Resource resource      => resource.ToDto(),
        Reagent reagent        => reagent.ToDto(),
        string str             => str,
        ICollection collection => collection.Cast<object>().Select(MapValue).ToList(),
        _                      => value
    };
    
    internal static IQueryable AsNoTrackingDynamic(this IQueryable source, StationContext ctx)
    {
        Type elementType = source.ElementType;

        MethodInfo method = typeof(EntityFrameworkQueryableExtensions)
            .GetMethods()
            .First
            (
                m =>
                m.Name == nameof(EntityFrameworkQueryableExtensions.AsNoTracking)
                && m.GetParameters().Length == 1
            )
            .MakeGenericMethod(elementType);

        return (IQueryable)method.Invoke(null, [source])!;
    }
}
