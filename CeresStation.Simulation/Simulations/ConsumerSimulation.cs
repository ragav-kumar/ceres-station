using CeresStation.Context;
using CeresStation.Model;

namespace CeresStation.Simulation;

public class ConsumerSimulation : ISimulation
{
    public string Key => "consumer_simulation";

    public Task TickAsync(StationContext ctx, CancellationToken cancellationToken)
    {
        foreach (Consumer consumer in ctx.Consumers)
        {
            ConsumeResources(consumer);
        }
        
        return Task.CompletedTask;
    }

    private void ConsumeResources(Consumer consumer)
    {
        throw new NotImplementedException();
    }
}
