using CeresStation.Context;
using CeresStation.Model;

namespace CeresStation.Simulation;

public class ConsumerSimulation(ISimulationRandomizer randomizer) : ISimulation
{
    public string Key => "consumer_simulation";

    public Task TickAsync(StationContext ctx, CancellationToken _)
    {
        foreach (Consumer consumer in ctx.Consumers)
        {
            ConsumeResources(consumer);
        }
        
        return Task.CompletedTask;
    }

    private void ConsumeResources(Consumer consumer)
    {
        // Apply Gaussian fluctuation to the extraction rate
        float actualConsumption = randomizer.NextGaussian(consumer.ConsumptionRate, consumer.StandardDeviation);

        if (actualConsumption > consumer.Stockpile)
        {
            // TODO: Consequences for not feeding the consumer?
        }
        
        consumer.Stockpile -= actualConsumption;
    }
}
