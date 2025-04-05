using System.Reflection;
using CeresStation.Context;
using CeresStation.Dto;
using CeresStation.Model;
using Microsoft.AspNetCore.Mvc;

namespace CeresStation.Web.Controllers;

[ApiController]
[Route("api/[controller]/{entityTypeName}")]
public class ListController : ControllerBase
{
    private readonly StationContext _context;

    public ListController(StationContext context)
    {
        _context = context;
    }
    
    [HttpGet("Columns")]
    public IEnumerable<ColumnDto> GetColumns(string entityTypeName)
    {
        var entityType = ListExtensions.ToEntityType(entityTypeName);

        return _context
            .Columns
            .Where(c => c.EntityType == entityType)
            .OrderBy(o => o.Order)
            .ToList()
            .ToDto();
    }

    [HttpPut("Columns")]
    public async Task<IEnumerable<ColumnDto>> PutColumns(string entityTypeName, [FromBody] IList<ColumnDto> columns)
    {
        EntityType entityType = ListExtensions.ToEntityType(entityTypeName);

        _context.ApplyDtos(entityType, columns);
        await _context.SaveChangesAsync();

        return _context
            .Columns
            .Where(c => c.EntityType == entityType)
            .OrderBy(o => o.Order)
            .ToList()
            .ToDto();
    }

    [HttpGet]
    public ListDataDto GetListData(string entityTypeName)
    {
        var entityType = ListExtensions.ToEntityType(entityTypeName);
        
        // Get all relevant columns
        List<Column> columns = _context
            .Columns
            .Where(c => c.EntityType == entityType)
            .ToList();
        // Get raw data
        IQueryable query = _context.GetQueryable(ListExtensions.ToTableName(entityTypeName));

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
        
        IQueryable cleanedQuery = query.AsNoTrackingDynamic(_context).ColumnSelect(fieldNames);
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
