using CeresStation.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CeresStation.Context;

public class ProcessorConfiguration : IEntityTypeConfiguration<Processor>
{
    public void Configure(EntityTypeBuilder<Processor> builder)
    {
        builder.HasBaseType<EntityBase>();
        
        builder
            .HasMany(o => o.Inputs)
            .WithOne()
            .HasForeignKey("ProcessorInputId")
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .HasMany(o => o.Outputs)
            .WithOne()
            .HasForeignKey("ProcessorOutputId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
