using CeresStation.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CeresStation.Core.Configurations;

public class EntityBaseConfiguration : IEntityTypeConfiguration<EntityBase>
{
    public void Configure(EntityTypeBuilder<EntityBase> builder)
    {
        builder.OwnsOne(o => o.Position);
    }
}
