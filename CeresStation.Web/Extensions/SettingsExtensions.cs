using CeresStation.Core;
using CeresStation.Model;

namespace CeresStation.Web;

internal static class SettingsExtensions
{
    internal static GeneralSetting FixedSettings(this StationContext ctx) => ctx.Settings.Single();

    internal static async Task UpdateMoney(this StationContext ctx, long delta)
    {
        GeneralSetting settings = ctx.FixedSettings();
        settings.Money += delta;
        await ctx.SaveChangesAsync();
    }
}