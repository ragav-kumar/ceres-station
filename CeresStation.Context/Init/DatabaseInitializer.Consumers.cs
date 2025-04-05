using CeresStation.Model;

namespace CeresStation.Context.Init;

internal partial class DatabaseInitializer
{
    private readonly Guid _habitatAirSupplyId = new ("619782A2-AA2C-422D-B829-871F63DC1700");
    private readonly Guid _habitatWaterSupplyId = new("20E160F0-2344-4840-9EB4-B1FF8C9D072D");
    private readonly Guid _hydrogenVentId = new("B68C83DF-2B42-4797-916E-CE4E15DB63D4");
    private readonly Guid _powerStationFuelId = new("C24D2022-D642-45FD-BEB7-300FEBBBE179");
    private readonly Guid _powerStationOxidizerId = new("EDE4A193-EBBF-4A36-8104-3F15EF6BC00C");

    private readonly Position _powerStationPosition = new(0, 150.0e3, 0);
    
    internal async Task Consumers()
    {
        await AddConsumer("Habitat air supply", _habitatAirSupplyId, _oxygenId, RandomAround(1.0f), _ceresHabitatPosition);
        await AddConsumer("Habitat water supply", _habitatWaterSupplyId, _waterId, RandomAround(1.0f), _ceresHabitatPosition);
        await AddConsumer("Hydrogen vent", _hydrogenVentId, _hydrogenId, RandomAround(10.0f), _ceresHabitatPosition);
        
        float powerInput = RandomAround(1.0f);
        await AddConsumer("Power station - Fuel", _powerStationFuelId, _hydrogenId, 0.111f * powerInput, _powerStationPosition);
        await AddConsumer("Power station - Oxidizer", _powerStationOxidizerId, _oxygenId, 0.888f * powerInput, _powerStationPosition);
        
        // Initialize List columns
        _ctx.Columns.AddRange(
            new Column
            {
                EntityType = EntityType.Consumer,
                Order = 0,
                FieldType = FieldType.Model,
                DisplayName = "Name",
                Width = 100,
                FieldName = "Name",
            },
            new Column
            {
                EntityType = EntityType.Consumer,
                FieldType = FieldType.Model,
                Order = 1,
                DisplayName = "Consumption Rate",
                Width = 100,
                FieldName = "ConsumptionRate",
            },
            new Column
            {
                EntityType = EntityType.Consumer,
                FieldType = FieldType.Model,
                Order = 2,
                DisplayName = "Standard Deviation",
                Width = 100,
                FieldName = "StandardDeviation",
            },
            new Column
            {
                EntityType = EntityType.Consumer,
                FieldType = FieldType.Model,
                Order = 3,
                DisplayName = "Stockpile",
                Width = 100,
                FieldName = "Stockpile",
            },
            new Column
            {
                EntityType = EntityType.Consumer,
                FieldType = FieldType.Model,
                Order = 4,
                DisplayName = "Capacity",
                Width = 100,
                FieldName = "Capacity",
            }
        );
        await _ctx.SaveChangesAsync();
    }

    private async Task AddConsumer(string consumerName, Guid id, Guid resourceId, float consumptionRate, Position position)
    {
        Console.WriteLine($"Adding consumer: {consumerName}");
        _ctx.Consumers.Add(new Consumer
        {
            Id = id,
            Name = consumerName,
            ResourceId = resourceId,
            ConsumptionRate = consumptionRate,
            StandardDeviation = RandomAround(0.1f),
            Stockpile = 0.0f,
            Capacity = RandomAround(100.0f),
            Position = new Position(position)
        });
        await _ctx.SaveChangesAsync();
    }
}
