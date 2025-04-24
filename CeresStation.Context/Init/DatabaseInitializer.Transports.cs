using CeresStation.Model;
using Microsoft.EntityFrameworkCore;

namespace CeresStation.Context.Init;

internal partial class DatabaseInitializer
{
    // Routes
    
    // Transports
    private readonly Guid _transport1Id = new("26416949-9CFE-447B-AB93-3E0BF00392B0");
    private readonly Guid _transport2Id = new("221454DB-437E-4B7E-A70B-37E70A64DB26");
    private readonly Guid _transport3Id = new("04C2EAE5-823F-4A60-ADC0-CD9CEAEAA87E");
    private readonly Guid _transport4Id = new("801F40B0-BDF6-459A-AC81-8C5551B0A44E");
    private readonly Guid _transport5Id = new("790A3289-4FD0-4340-BEF5-34907B974D77");
    private readonly Guid _transport6Id = new("B1B81E35-19AD-4D7A-9375-CC7DE63A11E0");
    private readonly Guid _transport7Id = new("BD291046-BE3B-409A-B125-9317E8F92745");
    
    internal async Task Transports()
    {
        await AddTransport("Hell's Nose"     , _transport1Id, _waterId   , _iceMineToElectrolyzerRouteId);
        await AddTransport("Void Hauler"     , _transport2Id, _waterId   , _iceMineToElectrolyzerToHabitatRouteId);
        await AddTransport("Iron Widow"      , _transport3Id, _waterId   , _iceMineToElectrolyzerToHabitatRouteId);
        await AddTransport("Nebula Jack"     , _transport4Id, _oxygenId  , _electrolyzerToHabitatRouteId);
        await AddTransport("Graveline Runner", _transport5Id, _oxygenId  , _electrolyzerToPowerRouteId);
        await AddTransport("Red Dust Express", _transport6Id, _hydrogenId, _electrolyzerToPowerRouteId);
        await AddTransport("The Black Spur"  , _transport7Id, _hydrogenId, _electrolyzerToHydrogenVentRouteId);

        // Initialize List columns
        _ctx.Columns.AddRange(
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
                DisplayName = "Route",
                Width = 100,
                FieldName = "Route",
            },
            new Column
            {
                EntityType = EntityType.Transport,
                Order = 3,
                FieldType = FieldType.Model,
                DisplayName = "Resource",
                Width = 100,
                FieldName = "CargoType",
            },
            new Column
            {
                EntityType = EntityType.Transport,
                Order = 4,
                FieldType = FieldType.Model,
                DisplayName = "Current Cargo",
                Width = 100,
                FieldName = "Stockpile",
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
                DisplayName = "Average Acceleration",
                Width = 100,
                FieldName = "Acceleration",
            }
        );
        await _ctx.SaveChangesAsync();
    }

    private async Task AddTransport(string transportName, Guid transportId, Guid resourceId, Guid routeId)
    {
        Console.WriteLine($"Adding transport: {transportName}");
        
        TransportRoute route = _ctx
            .TransportRoutes
            .Include(transportRoute => transportRoute.Waypoints)
            .Single(o => o.Id == routeId);
        
        Position position = route.WaypointEntities.First().Position;
        
        _ctx.Transports.Add(new Transport
        {
            Id = transportId,
            Name = transportName,
            Position = new Position(position),
            CargoTypeId = resourceId,
            Stockpile = 0,
            Capacity = RandomAround(50.0f),
            Acceleration = RandomAround(0.018f),
            StandardDeviation = RandomAround(0.002f),
            RouteId = routeId,
            NextWaypointIndex = 0
        });
        await _ctx.SaveChangesAsync();
    }
}
