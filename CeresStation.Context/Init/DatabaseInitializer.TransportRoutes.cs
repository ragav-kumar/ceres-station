using CeresStation.Model;

namespace CeresStation.Context.Init;

internal partial class DatabaseInitializer
{
    private readonly Guid _iceMineToElectrolyzerRouteId = new("D0305868-9C84-4DB5-9943-9EE0705EEA7F");
    private readonly Guid _iceMineToElectrolyzerToHabitatRouteId = new("21AAC5B3-89CD-4CE8-9606-29C8B2E5AEC0");
    private readonly Guid _electrolyzerToHabitatRouteId = new("3DB94E4B-0C5C-4EB8-B4FD-78A82DD39A9D");
    private readonly Guid _electrolyzerToPowerRouteId = new("8A493E52-3022-47D7-A154-1D55119F1747");
    private readonly Guid _electrolyzerToHydrogenVentRouteId = new("0C3AE05E-EA7E-4EF7-9BD5-C1A1E04C3A51");

    internal async Task TransportRoutes()
    {
        await AddTransportRoute("Ice Mine To Electrolyzer", _iceMineToElectrolyzerRouteId, _iceMineId, _waterElectrolyzerId);
        await AddTransportRoute("Ice mine to Habitat to Electrolyzer", _iceMineToElectrolyzerToHabitatRouteId, _iceMineId, _habitatWaterSupplyId, _waterElectrolyzerId);
        await AddTransportRoute("Electrolyzer to Habitat", _electrolyzerToHabitatRouteId, _waterElectrolyzerId, _habitatAirSupplyId);
        await AddTransportRoute("Electrolyzer to Power station", _electrolyzerToPowerRouteId, _waterElectrolyzerId, _powerStationFuelId);
        await AddTransportRoute("Electrolyzer to Hydrogen Vent", _electrolyzerToHydrogenVentRouteId, _waterElectrolyzerId, _hydrogenVentId);
    }

    private async Task AddTransportRoute(string routeName, Guid routeId, params Guid[] waypointIds)
    {
        Console.WriteLine($"Adding transport route: {routeName}");

        List<TransportRouteWaypoint> waypoints = waypointIds
            .Select((id, index) => new TransportRouteWaypoint
            {
                RouteId = routeId,
                EntityId = id,
                OrderIndex = index
            })
            .ToList();
        
        _ctx.TransportRoutes.Add(new TransportRoute
        {
            Id = routeId,
            Name = routeName,
            Waypoints = waypoints,
        });
        await _ctx.SaveChangesAsync();
    }
}
