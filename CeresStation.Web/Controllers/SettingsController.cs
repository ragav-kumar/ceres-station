using CeresStation.Context;
using CeresStation.Model;
using Microsoft.AspNetCore.Mvc;

namespace CeresStation.Web;

[ApiController]
[Route("api/[controller]")]
public class SettingsController : ControllerBase
{
    private readonly StationContext _context;

    public SettingsController(StationContext context)
    {
        _context = context;
    }

    [HttpGet("Money")]
    public async Task<long> GetMoney()
    {
        GeneralSetting settings = await _context.FixedSettingsAsync();
        return settings.Money;
    }

    [HttpPut("Money")]
    public async Task<long> UpdateMoney(long moneyDelta)
    {
        await _context.UpdateMoneyAsync(moneyDelta);
        return await GetMoney();
    }
}
