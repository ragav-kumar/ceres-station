using AutoMapper;
using CeresStation.Dto;
using CeresStation.Model;
using Microsoft.AspNetCore.Mvc;

namespace CeresStation.Web.Controllers;

[Route("api/[controller]")]
public partial class ExtractorsController(IMapper mapper) : CrudController<Extractor, ExtractorDto>(mapper)
{
}