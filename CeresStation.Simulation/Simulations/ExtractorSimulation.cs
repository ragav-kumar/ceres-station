using CeresStation.Context;
using CeresStation.Model;

namespace CeresStation.Simulation;

public class ExtractorSimulation : ISimulation
{
    private readonly Random _random = Random.Shared;

    public string Key => "extractor_simulation";

    public Task TickAsync(StationContext ctx, CancellationToken _)
    {
        foreach (Extractor extractor in ctx.Extractors.Where(o => o.Stockpile < o.Capacity))
        {
            AddToStockPile(extractor);
        }

        return Task.CompletedTask;
    }

    private void AddToStockPile(Extractor extractor)
    {
        // Apply Gaussian fluctuation to the extraction rate
        float actualExtraction = _random.NextGaussian(extractor.ExtractionRate, extractor.StandardDeviation);

        float newValue = MathF.Min(extractor.Capacity, extractor.Stockpile + actualExtraction);
        extractor.Stockpile = newValue;
    }
}
