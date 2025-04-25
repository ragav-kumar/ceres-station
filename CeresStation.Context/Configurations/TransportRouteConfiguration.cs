using CeresStation.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CeresStation.Context;

public class TransportRouteConfiguration: IEntityTypeConfiguration<TransportRoute>
{
    public void Configure(EntityTypeBuilder<TransportRoute> builder)
    {
        builder.HasKey(o => o.Id);

        builder
            .HasMany(o => o.Waypoints)
            .WithOne()
            .HasForeignKey(o => o.RouteId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
