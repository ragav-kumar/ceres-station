using CeresStation.Core;
using CeresStation.Model;

namespace CeresStation.Web.Extensions;

public static class SettingsExtensions
{
    public static GeneralSetting FixedSettings(this StationContext ctx) => ctx.Settings.Single();

    public static async Task UpdateMoney(this StationContext ctx, long delta)
    {
        GeneralSetting settings = ctx.FixedSettings();
        settings.Money += delta;
        await ctx.SaveChangesAsync();
    }
}