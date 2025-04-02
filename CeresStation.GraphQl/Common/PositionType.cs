using CeresStation.Model;

namespace CeresStation.GraphQl;

public class PositionType : ObjectType<Position>
{
    protected override void Configure(IObjectTypeDescriptor<Position> descriptor)
    {
        descriptor.Field(p => p.X);
        descriptor.Field(p => p.Y);
        descriptor.Field(p => p.Z);
    }
}
