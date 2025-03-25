using CeresStation.Core;
using CeresStation.Dto;
using CeresStation.Model;

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
        ctx.RemoveRange(toDelete);
        
        // Add
        List<Column> toAdd = dtoSet
            .Where(o => modelSet.All(m => m.Id != o.Id))
            .ToModel()
            .ToList();
        ctx.AddRange(toAdd);
        
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
}