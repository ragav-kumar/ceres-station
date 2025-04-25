using CeresStation.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CeresStation.Context;

public class TransportRouteWaypointConfiguration: IEntityTypeConfiguration<TransportRouteWaypoint>
{
    public void Configure(EntityTypeBuilder<TransportRouteWaypoint> builder)
    {
        builder
            .HasKey(o => new { o.RouteId, WaypointId = o.EntityId });
        
        builder
            .HasOne(o => o.Route)
            .WithMany("Waypoints")
            .HasForeignKey(o => o.RouteId)
            .HasPrincipalKey(o => o.Id)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(o => o.Entity)
            .WithMany()
            .HasForeignKey(o => o.EntityId)
            .HasPrincipalKey(o => o.Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
