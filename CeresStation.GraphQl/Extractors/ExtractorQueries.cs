using CeresStation.Core;
using CeresStation.Dto;

namespace CeresStation.GraphQl;

[ExtendObjectType(Name = "Query")]
public class ExtractorQueries
{
    //public async Task<List<ExtractorDto>> GetExtractors(StationContext ctx) => ctx.Extractors.ToDto().ToList();
}
