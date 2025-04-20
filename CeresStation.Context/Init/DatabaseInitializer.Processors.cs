using CeresStation.Model;

namespace CeresStation.Context.Init;

internal partial class DatabaseInitializer
{
    private readonly Guid _waterElectrolyzerId = new("F8FD5BEC-6EF9-4811-90D1-4E85054CEB61");
    private readonly Guid _waterElectrolyzerReagentWaterId = new("D690A4C7-556B-4773-AEF6-4931F3324FB9");
    private readonly Guid _waterElectrolyzerReagentHydrogenId = new("FB110386-3BBF-4C70-BB1C-46A05FAD84C5");
    private readonly Guid _waterElectrolyzerReagentOxygenId = new("74AB4B64-6F7F-470E-AF72-E2A8FEC22F29");
    
    private readonly Position _waterElectrolyzerPosition = new(-200.0e3, 0, 50.0e3);
    
    internal async Task Processors()
    {
        Console.WriteLine("Adding Processor: Water Electrolyzer");
        _ctx.Processors.Add(new Processor
        {
            Id = _waterElectrolyzerId,
            Name = "Water Electrolyzer",
            TimeStep = RandomAround(3.0f),
            Position = new Position(_waterElectrolyzerPosition),
            Inputs = [
                new Reagent
                {
                    Id = _waterElectrolyzerReagentWaterId,
                    ResourceId = _waterId,
                    ProcessRate = 1.0f,
                    Stockpile = 0f,
                    Capacity = 100.0f,
                }
            ],
            Outputs = [
                new Reagent
                {
                    Id = _waterElectrolyzerReagentHydrogenId,
                    ResourceId = _hydrogenId,
                    ProcessRate = 0.888f,
                    Stockpile = 0f,
                    Capacity = 100.0f,
                },
                new Reagent
                {
                    Id = _waterElectrolyzerReagentOxygenId,
                    ResourceId = _oxygenId,
                    ProcessRate = 0.112f,
                    Stockpile = 0f,
                    Capacity = 100.0f,
                }
            ],
        });
        await _ctx.SaveChangesAsync();
        
        // Initialize List columns
        // TODO: Add support for calculated columns (i.e. reagent list)
        _ctx.Columns.AddRange(
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
                Order = 1,
                FieldType = FieldType.Model,
                DisplayName = "Position",
                Width = 100,
                FieldName = "Position",
            },
            new Column
            {
                EntityType = EntityType.Processor,
                Order = 2,
                FieldType = FieldType.Model,
                DisplayName = "Time step",
                Width = 100,
                FieldName = "TimeStep",
            },
            new Column
            {
                EntityType = EntityType.Processor,
                Order = 3,
                FieldType = FieldType.Model,
                DisplayName = "Inputs",
                Width = 300,
                FieldName = "Inputs",
            },
            new Column
            {
                EntityType = EntityType.Processor,
                Order = 4,
                FieldType = FieldType.Model,
                DisplayName = "Outputs",
                Width = 300,
                FieldName = "Outputs",
            }
        );
        
        await _ctx.SaveChangesAsync();
    }
}
