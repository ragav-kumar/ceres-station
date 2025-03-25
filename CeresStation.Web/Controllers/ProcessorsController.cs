using CeresStation.Dto;
using CeresStation.Model;
using Microsoft.AspNetCore.Mvc;

namespace CeresStation.Web;

[Route("api/[controller]")]
public partial class ProcessorsController : CrudController<Processor, ProcessorDto>
{
}