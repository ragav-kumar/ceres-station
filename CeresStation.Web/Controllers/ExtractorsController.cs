using AutoMapper;
using CeresStation.Core;
using CeresStation.Dto;
using CeresStation.Model;
using CeresStation.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CeresStation.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExtractorsController(IMapper mapper) : ControllerBase
{
    [HttpGet]
    public IEnumerable<ExtractorDto> Get()
    {
        using StationContext ctx = new();
        return mapper.Map<IEnumerable<ExtractorDto>>(ctx.Extractors);
    }

    [HttpGet("{id:guid}")]
    public ExtractorDto Get(Guid id)
    {
        using StationContext ctx = new();
        return mapper.Map<ExtractorDto>(ctx.Extractors.Single(o => o.Id == id));
    }

    [HttpPost]
    public async Task<ExtractorDto> Create(ExtractorDto dto)
    {
        await using StationContext ctx = new();

        Extractor extractor = dto.ToNewModel(ctx);
        Guid extractorId = extractor.Id;
        ctx.Extractors.Add(extractor);
        await ctx.SaveChangesAsync();
        
        return mapper.Map<ExtractorDto>(ctx.Extractors.Single(o => o.Id == extractorId));
    }
}
