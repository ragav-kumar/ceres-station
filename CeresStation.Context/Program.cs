using CeresStation.Core;
using CeresStation.Model;
using Microsoft.EntityFrameworkCore;

await using StationContext ctx = new StationContext();

Console.WriteLine($"Database path: {ctx.DbPath}");

// Initialize
if (!ctx.Resources.Any(o => o.Name == "Iron"))
{
    ctx.Add(new Resource { Name = "Iron" });
    await ctx.SaveChangesAsync();
}

if (ctx.Extractors.Count() < 10)
{
    Resource iron = ctx.Resources.First();
    Random random = new Random();
    
    for (int i = 0; i < 10; i++)
    {
        ctx.Add(new Extractor
        {
            ResourceId = iron.Id,
            ExtractionRate = 1.0f + (random.NextSingle() - 0.5f),
            StandardDeviation = 0.1f + (random.NextSingle() - 0.5f) * 0.1f,
            Stockpile = 0.0f,
            Capacity = 100.0f + (random.NextSingle() - 0.5f) * 100f,
            Name = $"Extractor {i + 1}",
        });
    }
    await ctx.SaveChangesAsync();
}

if (!ctx.Columns.Any(o => o.EntityType == EntityType.Extractor))
{
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

Extractor extractor = ctx.Extractors.Include(extractor => extractor.Resource).First();
Console.WriteLine($"Extractor {extractor.Id} created: {extractor}");
Console.WriteLine($"Resource: {extractor.Resource.Name}");
