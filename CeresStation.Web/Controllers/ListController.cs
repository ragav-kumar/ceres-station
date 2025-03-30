using System.Reflection;
using CeresStation.Core;
using CeresStation.Dto;
using CeresStation.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CeresStation.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ListController
{
    [HttpGet("{entityTypeName}/Columns")]
    public IEnumerable<ColumnDto> GetColumns(string entityTypeName)
    {
        EntityType entityType = ListExtensions.ToEntityType(entityTypeName);

        using StationContext ctx = new();

        return ctx
            .Columns
            .Where(c => c.EntityType == entityType)
            .OrderBy(o => o.Order)
            .ToList()
            .ToDto();
    }

    [HttpPut("{entityTypeName}/Columns")]
    public async Task<IEnumerable<ColumnDto>> PutColumns(string entityTypeName, [FromBody] IList<ColumnDto> columns)
    {
        EntityType entityType = ListExtensions.ToEntityType(entityTypeName);

        await using StationContext ctx = new();
        ctx.ApplyDtos(entityType, columns);
        await ctx.SaveChangesAsync();

        return ctx
            .Columns
            .Where(c => c.EntityType == entityType)
            .OrderBy(o => o.Order)
            .ToList()
            .ToDto();
    }

    [HttpGet("{entityTypeName}")]
    public ListDataDto GetListData(string entityTypeName)
    {
        EntityType entityType = ListExtensions.ToEntityType(entityTypeName);
        using StationContext ctx = new();

        // Get all relevant columns
        List<Column> columns = ctx
            .Columns
            .Where(c => c.EntityType == entityType)
            .ToList();
        // Get raw data
        IQueryable query = ctx.GetQueryable(ListExtensions.ToTableName(entityTypeName));

        // For now, we only support field names.
        List<string> fieldNames = columns
            .Where(o => o.FieldType == FieldType.Model)
            .Select(o => o.FieldName!)
            .ToList();
        // Inject Id if needed.
        if (fieldNames.All(o => o != "Id"))
        {
            fieldNames.Add("Id");
        }
        
        IQueryable cleanedQuery = query.AsNoTrackingDynamic(ctx).ColumnSelect(fieldNames);
        List<object> rows = cleanedQuery.Cast<object>().ToList();

        List<ListRowDto> rowDtos = [];
        foreach (object row in rows)
        {
            ListRowDto rowDto = new();
            foreach (PropertyInfo prop in row.GetType().GetProperties())
            {
                rowDto[prop.Name] = prop.ToDto(row);
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
}
