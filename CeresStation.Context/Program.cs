using CeresStation.Core;
using CeresStation.Model;
using Microsoft.EntityFrameworkCore;

await using StationContext ctx = new StationContext();

Console.WriteLine($"Database path: {ctx.DbPath}");

// Create
Console.WriteLine("Create a new Extractor");

ctx.Add(new Resource { Name = "Iron" });
await ctx.SaveChangesAsync();

Resource iron = ctx.Resources.First();

ctx.Add(new Extractor
{
    ResourceId = iron.Id,
    ExtractionRate = 1.0f,
    StandardDeviation = 0.1f,
    Stockpile = 0.0f,
    Capacity = 100.0f,
    Name = "Extractor 1",
});
await ctx.SaveChangesAsync();

Extractor extractor = ctx.Extractors.Include(extractor => extractor.Resource).First();
Console.WriteLine($"Extractor {extractor.Id} created: {extractor}");
Console.WriteLine($"Resource: {extractor.Resource.Name}");
