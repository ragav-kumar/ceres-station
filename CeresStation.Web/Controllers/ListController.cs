using System.Reflection;
using AutoMapper;
using CeresStation.Core;
using CeresStation.Dto;
using CeresStation.Model;
using Microsoft.AspNetCore.Mvc;

namespace CeresStation.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ListController(IMapper mapper)
{
    [HttpGet("{entityTypeName}/Columns")]
    public IEnumerable<ColumnDto> GetColumns(string entityTypeName)
    {
        EntityType entityType = ToEntityType(entityTypeName);

        using StationContext ctx = new();
        
        return mapper.Map<IEnumerable<ColumnDto>>(ctx
            .Columns
            .Where(c => c.EntityType == entityType)
            .OrderBy(o => o.Order)
        );
    }

    [HttpPut("{entityTypeName}/Columns")]
    public async Task<IEnumerable<ColumnDto>> PutColumns(string entityTypeName, [FromBody] IList<ColumnDto> columns)
    {
        EntityType entityType = ToEntityType(entityTypeName);
        
        await using StationContext ctx = new();
        ApplyDtos(entityType, columns, ctx);
        await ctx.SaveChangesAsync();
        
        return mapper.Map<IEnumerable<ColumnDto>>(ctx
            .Columns
            .Where(c => c.EntityType == entityType)
            .OrderBy(o => o.Order)
        );
    }

    private static void ApplyDtos(EntityType entityType, IList<ColumnDto> dtos, StationContext ctx)
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
            .Select(CreateColumnFromDto)
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

    private static void ApplyDto(Column model, ColumnDto dto)
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

    private static Column CreateColumnFromDto(ColumnDto dto) => new()
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

    [HttpGet("{entityTypeName}")]
    public ListDataDto GetListData(string entityTypeName)
    {
        EntityType entityType = ToEntityType(entityTypeName);
        using StationContext ctx = new();

        // Get all relevant columns
        List<Column> columns = ctx
            .Columns
            .Where(c => c.EntityType == entityType)
            .ToList();
        // Get raw data
        IQueryable query = ctx.GetQueryable(ToTableName(entityTypeName));

        List<string> fieldNames = columns
            .Where(o => o.FieldType == FieldType.Model)
            .Select(o => o.FieldName!)
            .ToList();
        IQueryable cleanedQuery = query.ColumnSelect(fieldNames);
        List<object> rows = cleanedQuery.Cast<object>().ToList();

        List<ListRowDto> rowDtos = [];
        foreach (object row in rows)
        {
            ListRowDto rowDto = new();
            foreach (PropertyInfo prop in row.GetType().GetProperties())
            {
                rowDto[prop.Name] = prop.GetValue(row);
            }

            rowDtos.Add(rowDto);
        }

        string sortField = columns.MinBy(o => o.Order)!.FieldName!;

        rowDtos = rowDtos.OrderBy(o => o[sortField]).ToList();

        return new ListDataDto(
            Rows: rowDtos,
            TotalCount: rows.Count
        );
    }

    private static EntityType ToEntityType(string entityTypeName)
    {
        return entityTypeName.ToLower() switch
        {
            "extractor" or "extractors" => EntityType.Extractor,
            "processor" or "processors" => EntityType.Processor,
            "transport" or "transports" => EntityType.Transport,
            "consumer" or "consumers"   => EntityType.Consumer,
            _                           => throw new ArgumentException($"Unknown entity type: {entityTypeName}")
        };
    }

    private static string ToTableName(string entityTypeName)
    {
        return entityTypeName.ToLower() switch
        {
            "extractor" or "extractors" => "Extractor",
            "processor" or "processors" => "Processor",
            "transport" or "transports" => "Transport",
            "consumer" or "consumers"   => "Consumer",
            _                           => throw new ArgumentException($"Unknown entity type: {entityTypeName}")
        };
    }
}
