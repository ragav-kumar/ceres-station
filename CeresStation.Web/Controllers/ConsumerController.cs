using CeresStation.Context;
using CeresStation.Dto;
using CeresStation.Model;
using Microsoft.AspNetCore.Mvc;

namespace CeresStation.Web;

[Route("api/[controller]")]
public partial class ConsumerController: CrudController<Consumer, ConsumerDto>
{
    public ConsumerController(StationContext context) : base(context)
    {
    }
}
