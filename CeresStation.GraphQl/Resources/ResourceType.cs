using CeresStation.Model;

namespace CeresStation.GraphQl;

public class ResourceType : ObjectType<Resource>
{
    protected override void Configure(IObjectTypeDescriptor<Resource> descriptor)
    {
        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.Name);
    }
}
