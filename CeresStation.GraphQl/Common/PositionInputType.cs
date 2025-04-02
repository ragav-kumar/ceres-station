using CeresStation.Model;

namespace CeresStation.GraphQl;

public class PositionInputType : InputObjectType<Position>
{
    protected override void Configure(IInputObjectTypeDescriptor<Position> descriptor)
    {
        descriptor.Field(p => p.X);
        descriptor.Field(p => p.Y);
        descriptor.Field(p => p.Z);
    }
}
