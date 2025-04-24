using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace CeresStation.Model;

[SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
[SuppressMessage("ReSharper", "PropertyCanBeMadeInitOnly.Global")]
[PrimaryKey(nameof(WaypointId), nameof(RouteId))]
public class TransportRouteWaypoint
{
    public Guid RouteId { get; set; }
    public virtual TransportRoute Route { get; set; }
    
    public Guid WaypointId { get; set; }
    public virtual EntityBase Waypoint { get; set; }
    
    public required int OrderIndex { get; set; }
}
