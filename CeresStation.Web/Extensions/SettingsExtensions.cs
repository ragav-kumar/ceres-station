using CeresStation.Core;
using CeresStation.Model;
using Microsoft.EntityFrameworkCore;

namespace CeresStation.Web;

internal static class SettingsExtensions
{
    internal static async Task<GeneralSetting> FixedSettingsAsync(this StationContext ctx) => await ctx.Settings.SingleAsync();

    internal static async Task UpdateMoneyAsync(this StationContext ctx, long delta)
    {
        GeneralSetting settings = await ctx.FixedSettingsAsync();
        settings.Money += delta;
        await ctx.SaveChangesAsync();
    }
}
