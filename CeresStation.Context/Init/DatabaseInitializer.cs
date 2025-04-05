using CeresStation.Model;

namespace CeresStation.Context.Init;

internal partial class DatabaseInitializer
{
    private readonly Position _ceresHabitatPosition = Position.Origin;
    
    private readonly StationContext _ctx;
    private readonly Random _random = new(1);

    internal DatabaseInitializer(StationContext context)
    {
        _ctx = context;
    }

    public async Task Settings()
    {
        _ctx.Settings.Add(new GeneralSetting
        {
            Id = Guid.Empty,
            Money = 1_000_000
        });
        await _ctx.SaveChangesAsync();
    }

    private float RandomAround(float mean) => mean * (0.5f + _random.NextSingle());
}
