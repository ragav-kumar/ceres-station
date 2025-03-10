using CeresStation.Model;

namespace CeresStation.Core.Init;

internal class DatabaseInitializer
{
    private readonly StationContext ctx;
    private readonly Random random = new(1);

    internal DatabaseInitializer(StationContext context)
    {
        ctx = context;
    }

    internal async Task Resources()
    {
        ctx.Add(new Resource { Id = Guid.NewGuid(), Name = "Iron" });
        ctx.Add(new Resource { Id = Guid.NewGuid(), Name = "Copper" });
        ctx.Add(new Resource { Id = Guid.NewGuid(), Name = "Silicates" });
        ctx.Add(new Resource { Id = Guid.NewGuid(), Name = "Carbon" });
        ctx.Add(new Resource { Id = Guid.NewGuid(), Name = "Water" });
        ctx.Add(new Resource { Id = Guid.NewGuid(), Name = "Hydrogen" });
        ctx.Add(new Resource { Id = Guid.NewGuid(), Name = "Oxygen" });
        await ctx.SaveChangesAsync();
        
        // Not Listable, so no columns
    }

    internal async Task Extractors()
    {
        AddExtractor("Iron Mine", "Iron");
        AddExtractor("Copper Mine", "Copper");
        AddExtractor("Rock Quarry", "Silicates");
        AddExtractor("Ice Mine", "Water");
        await ctx.SaveChangesAsync();

        // Initialize List columns
        ctx.AddRange(
            new Column
            {
                EntityType = EntityType.Extractor,
                Order = 0,
                FieldType = FieldType.Model,
                DisplayName = "Name",
                Width = 100,
                FieldName = "Name",
            },
            new Column
            {
                EntityType = EntityType.Extractor,
                FieldType = FieldType.Model,
                Order = 1,
                DisplayName = "Extraction Rate",
                Width = 100,
                FieldName = "ExtractionRate",
            },
            new Column
            {
                EntityType = EntityType.Extractor,
                FieldType = FieldType.Model,
                Order = 1,
                DisplayName = "Standard Deviation",
                Width = 100,
                FieldName = "StandardDeviation",
            },
            new Column
            {
                EntityType = EntityType.Extractor,
                FieldType = FieldType.Model,
                Order = 1,
                DisplayName = "Stockpile",
                Width = 100,
                FieldName = "Stockpile",
            },
            new Column
            {
                EntityType = EntityType.Extractor,
                FieldType = FieldType.Model,
                Order = 1,
                DisplayName = "Capacity",
                Width = 100,
                FieldName = "Capacity",
            }
        );
        await ctx.SaveChangesAsync();
    }

    private void AddExtractor(string extractorName, string resourceName)
    {
        Resource resource = ctx.Resources.Single(o => o.Name == resourceName);
        ctx.Add(new Extractor
        {
            Id = Guid.NewGuid(),
            Name = extractorName,
            ResourceId = resource.Id,
            ExtractionRate = 1.0f + (random.NextSingle() - 0.5f),
            StandardDeviation = 0.1f + (random.NextSingle() - 0.5f) * 0.1f,
            Stockpile = 0.0f,
            Capacity = 100.0f + (random.NextSingle() - 0.5f) * 100f,
        });
    }

    internal async Task Processors()
    {
        // TODO
        await ctx.SaveChangesAsync();
    }

    internal async Task Consumers()
    {
        // TODO
        await ctx.SaveChangesAsync();
    }

    internal async Task Transports()
    {
        // TODO
        await ctx.SaveChangesAsync();
    }
}
