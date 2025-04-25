using CeresStation.Dto;
using CeresStation.Model;

namespace CeresStation.Web;

internal static class TransportRouteExtensions
{
    internal static TransportRouteDto ToDto(this TransportRoute transportRoute) => new(
        Id: transportRoute.Id,
        Name: transportRoute.Name,
        Waypoints: transportRoute.Waypoints.ToDto().ToList()
    );

    internal static EntityDto ToDto(this TransportRouteWaypoint waypoint) => waypoint.Entity.ToDto();

    internal static IEnumerable<EntityDto> ToDto(this IEnumerable<TransportRouteWaypoint> waypoints) => waypoints.Select(ToDto);
}
