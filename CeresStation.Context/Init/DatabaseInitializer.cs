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

    private float RandomAround(float mean) => mean * (0.5f + random.NextSingle());
}
