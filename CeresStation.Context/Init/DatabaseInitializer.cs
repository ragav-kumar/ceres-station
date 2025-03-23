using CeresStation.Model;

namespace CeresStation.Core.Init;

internal partial class DatabaseInitializer
{
    private readonly Position ceresHabitatPosition = Position.Origin;
    
    private readonly StationContext ctx;
    private readonly Random random = new(1);

    internal DatabaseInitializer(StationContext context)
    {
        ctx = context;
    }

    public async Task Settings()
    {
        ctx.Add(new GeneralSetting
        {
            Id = Guid.Empty,
            Money = 1_000_000
        });
        await ctx.SaveChangesAsync();
    }

    private float RandomAround(float mean) => mean * (0.5f + random.NextSingle());
}
