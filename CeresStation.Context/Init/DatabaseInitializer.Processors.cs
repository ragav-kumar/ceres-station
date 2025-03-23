using CeresStation.Model;

namespace CeresStation.Core.Init;

internal partial class DatabaseInitializer
{
    private readonly Guid waterElectrolyzerId = new("F8FD5BEC-6EF9-4811-90D1-4E85054CEB61");
    private readonly Guid waterElectrolyzerReagentWaterId = new("D690A4C7-556B-4773-AEF6-4931F3324FB9");
    private readonly Guid waterElectrolyzerReagentHydrogenId = new("FB110386-3BBF-4C70-BB1C-46A05FAD84C5");
    private readonly Guid waterElectrolyzerReagentOxygenId = new("74AB4B64-6F7F-470E-AF72-E2A8FEC22F29");
    
    private readonly Position waterElectrolyzerPosition = new(-200.0e3, 0, 50.0e3);
    
    internal async Task Processors()
    {
        Console.WriteLine("Adding Processor: Water Electrolyzer");
        ctx.Add(new Processor
        {
            Id = waterElectrolyzerId,
            Name = "Water Electrolyzer",
            TimeStep = RandomAround(3.0f),
            Position = new Position(waterElectrolyzerPosition),
            Inputs = [
                new Reagent
                {
                    Id = waterElectrolyzerReagentWaterId,
                    ResourceId = waterId,
                    Count = 1.0f,
                    StockpileCapacity = 100.0f,
                }
            ],
            Outputs = [
                new Reagent
                {
                    Id = waterElectrolyzerReagentHydrogenId,
                    ResourceId = hydrogenId,
                    Count = 0.888f,
                    StockpileCapacity = 100.0f,
                },
                new Reagent
                {
                    Id = waterElectrolyzerReagentOxygenId,
                    ResourceId = oxygenId,
                    Count = 0.112f,
                    StockpileCapacity = 100.0f,
                }
            ],
        });
        await ctx.SaveChangesAsync();
        
        // Initialize List columns
        // TODO: Add support for calculated columns (i.e. reagent list)
        ctx.AddRange(
            new Column
            {
                EntityType = EntityType.Processor,
                Order = 0,
                FieldType = FieldType.Model,
                DisplayName = "Name",
                Width = 100,
                FieldName = "Name",
            },
            new Column
            {
                EntityType = EntityType.Processor,
                Order = 0,
                FieldType = FieldType.Model,
                DisplayName = "Time step",
                Width = 100,
                FieldName = "TimeStep",
            }
        );
        
        await ctx.SaveChangesAsync();
    }
}
