using CeresStation.Dto;

namespace CeresStation.GraphQl;

public class ExtractorInputType : InputObjectType<ExtractorDto>
{
    protected override void Configure(IInputObjectTypeDescriptor<ExtractorDto> descriptor)
    {
        //descriptor.Field(o => o.)
    }
}
