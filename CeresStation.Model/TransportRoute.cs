using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace CeresStation.Model;

[SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
[SuppressMessage("ReSharper", "PropertyCanBeMadeInitOnly.Global")]
[PrimaryKey(nameof(Id))]
public class TransportRoute
{
    public Guid Id { get; set; }

    [MaxLength(100)]
    public required string Name { get; set; }

    public virtual List<TransportRouteWaypoint> Waypoints { get; set; }

    [NotMapped]
    public List<EntityBase> WaypointEntities => Waypoints
        .OrderBy(o => o.OrderIndex)
        .Select(o => o.Waypoint)
        .ToList() ?? [];
}
