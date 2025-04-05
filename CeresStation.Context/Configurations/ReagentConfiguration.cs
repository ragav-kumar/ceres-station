using CeresStation.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CeresStation.Context;

public class ReagentConfiguration : IEntityTypeConfiguration<Reagent>
{
    public void Configure(EntityTypeBuilder<Reagent> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(r => r.Resource)
            .WithMany()
            .HasForeignKey(r => r.ResourceId)
            .OnDelete(DeleteBehavior.Restrict);

        // Shadow properties for Processor linkage
        builder.Property<Guid?>("ProcessorInputId");
        builder.Property<Guid?>("ProcessorOutputId");
    }
}
