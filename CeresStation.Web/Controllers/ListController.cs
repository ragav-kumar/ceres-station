using System.Reflection;
using AutoMapper;
using CeresStation.Core;
using CeresStation.Dto;
using CeresStation.Model;
using Microsoft.AspNetCore.Mvc;

namespace CeresStation.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ListController
{
    private readonly IMapper mapper;

    public ListController(IMapper mapper)
    {
        this.mapper = mapper;
    }

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

        ListDataDto data = new() { TotalCount = rows.Count, Rows = [] };
        foreach (object row in rows)
        {
            ListRowDto rowDto = new();
            foreach (PropertyInfo prop in row.GetType().GetProperties())
            {
                rowDto[prop.Name] = prop.GetValue(row);
            }

            data.Rows.Add(rowDto);
        }

        string sortField = columns.MinBy(o => o.Order)!.FieldName!;

        data.Rows = data.Rows.OrderBy(o => o[sortField]).ToList();

        return data;
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
