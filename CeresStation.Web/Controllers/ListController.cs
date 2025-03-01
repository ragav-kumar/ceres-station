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
        EntityType entityType = Enum.Parse<EntityType>(entityTypeName);

        using StationContext ctx = new StationContext();
        return mapper.Map<IEnumerable<ColumnDto>>(ctx.Columns.Where(c => c.EntityType == entityType));
    }

    public IEnumerable<ListDataDto> GetListData(string entityTypeName)
    {
        EntityType entityType = Enum.Parse<EntityType>(entityTypeName);
        using StationContext ctx = new StationContext();

        // Get all relevant columns
        List<Column> columns = ctx
            .Columns
            .Where(c => c.EntityType == entityType)
            .ToList();
        // Get raw data
        IQueryable query = ctx.GetQueryable(entityTypeName);
        List<string> fieldNames = columns
            .Where(o => o.FieldType == FieldType.Model)
            .Select(o => o.FieldName!)
            .ToList();
        IQueryable cleanedQuery = query.ColumnSelect(fieldNames);
    }
}
