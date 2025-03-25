﻿using CeresStation.Core;
using Microsoft.AspNetCore.Mvc;

namespace CeresStation.Web;

[ApiController]
[Route("api/[controller]")]
public class SettingsController : ControllerBase
{
    [HttpGet("Money")]
    public async Task<long> GetMoney()
    {
        await using StationContext ctx = new();
        return ctx.FixedSettings().Money;
    }

    [HttpPut("Money")]
    public async Task<long> UpdateMoney(long moneyDelta)
    {
        await using StationContext ctx = new();
        await ctx.UpdateMoney(moneyDelta);
        return ctx.FixedSettings().Money;
    }
}