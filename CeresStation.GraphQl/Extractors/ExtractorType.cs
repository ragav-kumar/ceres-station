using CeresStation.Model;

namespace CeresStation.GraphQl;

public class ExtractorType : ObjectType<Extractor>
{
    protected override void Configure(IObjectTypeDescriptor<Extractor> descriptor)
    {
        descriptor.Field(o => o.Id);
        descriptor.Field(o => o.Name);
        descriptor.Field(o => o.Position).Type<PositionType>();
        descriptor.Field(o => o.ExtractionRate);
        descriptor.Field(o => o.Capacity);
        descriptor.Field(o => o.Stockpile);
        descriptor.Field(o => o.StandardDeviation);
        descriptor.Field(o => o.Resource);
    }
}
