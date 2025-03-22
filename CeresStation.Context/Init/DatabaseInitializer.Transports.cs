using CeresStation.Model;

namespace CeresStation.Core.Init;

internal partial class DatabaseInitializer
{
    private readonly Guid iceMineToElectrolyzerId = new("D0305868-9C84-4DB5-9943-9EE0705EEA7F");
    private readonly Guid iceMineToHabitatId = new("26416949-9CFE-447B-AB93-3E0BF00392B0");
    private readonly Guid electrolyzerToHabitatOxygenId = new("221454DB-437E-4B7E-A70B-37E70A64DB26");
    private readonly Guid electrolyzerToPowerOxygenId = new("8A493E52-3022-47D7-A154-1D55119F1747");
    private readonly Guid electrolyzerToPowerHydrogenId = new("04C2EAE5-823F-4A60-ADC0-CD9CEAEAA87E");
    private readonly Guid electrolyzerToHydrogenVentId = new("0C3AE05E-EA7E-4EF7-9BD5-C1A1E04C3A51");
    
    internal async Task Transports()
    {
        AddTransport("Electrolyzer Water supply shuttle", iceMineToElectrolyzerId, waterId, iceMineId, waterElectrolyzerId);
        AddTransport("Habitat Water supply shuttle", iceMineToHabitatId, waterId, iceMineId, habitatWaterSupplyId);
        AddTransport("Habitat Oxygen supply shuttle", electrolyzerToHabitatOxygenId, oxygenId, waterElectrolyzerId, habitatAirSupplyId);
        AddTransport("Power station Oxidizer supply shuttle", electrolyzerToPowerOxygenId, oxygenId, waterElectrolyzerId, powerStationOxidizerId);
        AddTransport("Power station Fuel supply shuttle", electrolyzerToPowerHydrogenId, hydrogenId, waterElectrolyzerId, powerStationFuelId);
        AddTransport("Hydrogen disposal conduit", electrolyzerToHydrogenVentId, hydrogenId, waterElectrolyzerId, hydrogenVentId);
        await ctx.SaveChangesAsync();
        
        // Initialize List columns
        ctx.AddRange(
            new Column
            {
                EntityType = EntityType.Transport,
                Order = 0,
                FieldType = FieldType.Model,
                DisplayName = "Name",
                Width = 100,
                FieldName = "Name",
            },
            new Column
            {
                EntityType = EntityType.Transport,
                Order = 1,
                FieldType = FieldType.Model,
                DisplayName = "Source",
                Width = 100,
                FieldName = "Source",
            },
            new Column
            {
                EntityType = EntityType.Transport,
                Order = 2,
                FieldType = FieldType.Model,
                DisplayName = "Destination",
                Width = 100,
                FieldName = "Destination",
            },
            new Column
            {
                EntityType = EntityType.Transport,
                Order = 3,
                FieldType = FieldType.Model,
                DisplayName = "Resource",
                Width = 100,
                FieldName = "Resource",
            },
            new Column
            {
                EntityType = EntityType.Transport,
                Order = 4,
                FieldType = FieldType.Model,
                DisplayName = "Current Cargo",
                Width = 100,
                FieldName = "CurrentCargo",
            },
            new Column
            {
                EntityType = EntityType.Transport,
                Order = 5,
                FieldType = FieldType.Model,
                DisplayName = "Capacity",
                Width = 100,
                FieldName = "Capacity",
            },
            new Column
            {
                EntityType = EntityType.Transport,
                Order = 6,
                FieldType = FieldType.Model,
                DisplayName = "Trip time standard deviation",
                Width = 100,
                FieldName = "TripTimeStandardDeviation",
            }
        );
        await ctx.SaveChangesAsync();
    }

    private void AddTransport(string transportName, Guid transportId, Guid resourceId, Guid sourceId, Guid destinationId)
    {
        Console.WriteLine($"Adding transport: {transportName}");
        
        EntityBase source = ctx.Entities.Single(o => o.Id == sourceId);
        Position sourcePosition = source.Position;
        
        ctx.Add(new Transport
        {
            Id = transportId,
            Name = transportName,
            Position = sourcePosition,
            SourceId = sourceId,
            DestinationId = destinationId,
            ResourceId = resourceId,
            CurrentCargo = 0,
            Capacity = RandomAround(50.0f),
            TripTimeStandardDeviation = RandomAround(0.1f)
        });
    }
}
