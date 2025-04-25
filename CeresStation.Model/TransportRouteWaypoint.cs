using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace CeresStation.Model;

[SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
[SuppressMessage("ReSharper", "PropertyCanBeMadeInitOnly.Global")]
[PrimaryKey(nameof(EntityId), nameof(RouteId))]
public class TransportRouteWaypoint
{
    public Guid RouteId { get; set; }
    public virtual TransportRoute Route { get; set; }
    
    public Guid EntityId { get; set; }
    public virtual EntityBase Entity { get; set; }
    
    public required int OrderIndex { get; set; }
}
