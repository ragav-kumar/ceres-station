using CeresStation.Context;

namespace CeresStation.Simulation;

public interface ISimulation
{
    public string Key { get; }
    public Task TickAsync(StationContext ctx, CancellationToken cancellationToken);
}
