using CeresStation.Context;
using CeresStation.Dto;
using CeresStation.Model;
using Microsoft.AspNetCore.Mvc;

namespace CeresStation.Web;

[Route("api/[controller]")]
public partial class TransportsController : CrudController<Transport, TransportDto>
{
    public TransportsController(StationContext context) : base(context)
    {
    }
}
