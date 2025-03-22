using CeresStation.Model;

namespace CeresStation.Core.Init;

internal partial class DatabaseInitializer
{
    private readonly Guid ironMineId = new("F944DC86-DB9A-4403-B500-EEE21BE0F789");
    private readonly Guid copperMineId = new("302B5BD0-4654-4E78-86DF-0BBD435ACBFA");
    private readonly Guid rockQuarryId = new("FA5DD16B-D83E-48FF-9154-94904EC79371");
    private readonly Guid iceMineId = new("25F425F6-8B5D-43CD-8B77-1FD4CE3904B3");

    private readonly Position ironMinePosition = new(1.8e9, 3.2e9, 0.3e9);
    private readonly Position copperMinePosition = new(-2.0e9, -2.6e9, -0.1e9);
    private readonly Position rockQuarryPosition = new(4.9e9, 0.5e9, 0.0e9);
    private readonly Position iceMinePosition = new(0.0e9, -4.0e9, 0.2e9);
    
    internal async Task Extractors()
    {
        AddExtractor("Iron Mine", ironMineId, ironId, ironMinePosition);
        AddExtractor("Copper Mine", copperMineId, copperId, copperMinePosition);
        AddExtractor("Rock Quarry", rockQuarryId, silicatesId, rockQuarryPosition);
        AddExtractor("Ice Mine", iceMineId, waterId, iceMinePosition);
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
                Order = 2,
                DisplayName = "Standard Deviation",
                Width = 100,
                FieldName = "StandardDeviation",
            },
            new Column
            {
                EntityType = EntityType.Extractor,
                FieldType = FieldType.Model,
                Order = 3,
                DisplayName = "Stockpile",
                Width = 100,
                FieldName = "Stockpile",
            },
            new Column
            {
                EntityType = EntityType.Extractor,
                FieldType = FieldType.Model,
                Order = 4,
                DisplayName = "Capacity",
                Width = 100,
                FieldName = "Capacity",
            }
        );
        await ctx.SaveChangesAsync();
    }

    private void AddExtractor(string extractorName, Guid extractorId, Guid resourceId, Position position)
    {
        ctx.Add(new Extractor
        {
            Id = extractorId,
            Name = extractorName,
            ResourceId = resourceId,
            ExtractionRate = RandomAround(1.0f),
            StandardDeviation = RandomAround(0.1f),
            Stockpile = 0.0f,
            Capacity = RandomAround(100.0f),
            Position = position,
        });
    }
}
