using CeresStation.Context;
using CeresStation.Model;
using CeresStation.TickService;
using Microsoft.EntityFrameworkCore;

namespace CeresStation.Simulation;

public class ExtractorSimulation : ITickable
{
    private readonly IDbContextFactory<StationContext> _contextFactory;
    private readonly Random _random = Random.Shared;

    public ExtractorSimulation(IDbContextFactory<StationContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task TickAsync(CancellationToken cancellationToken)
    {
        await using StationContext ctx = await _contextFactory.CreateDbContextAsync(cancellationToken);
        
        foreach (Extractor extractor in ctx.Extractors.Where(o => o.Stockpile < o.Capacity))
        {
            // Apply Gaussian fluctuation to the extraction rate
            float actualExtraction = _random.NextGaussian(extractor.ExtractionRate, extractor.StandardDeviation);

            extractor.Stockpile = MathF.Min(extractor.Capacity, extractor.Stockpile + actualExtraction);
        }

        await ctx.SaveChangesAsync(cancellationToken);
    }
}
