using AutoMapper;
using CeresStation.Core;
using CeresStation.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CeresStation.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExtractorsController : ControllerBase
{
    private readonly IMapper mapper;

    public ExtractorsController(IMapper mapper)
    {
        this.mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<ExtractorDto> Get()
    {
        using StationContext ctx = new StationContext();
        return mapper.Map<IEnumerable<ExtractorDto>>(ctx.Extractors);
    }

    [HttpGet("{id:guid}")]
    public ExtractorDto Get(Guid id)
    {
        using StationContext ctx = new StationContext();
        return mapper.Map<ExtractorDto>(ctx.Extractors.Single(o => o.Id == id));
    }
}
