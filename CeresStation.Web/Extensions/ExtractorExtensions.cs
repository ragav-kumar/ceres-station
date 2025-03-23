using CeresStation.Core;
using CeresStation.Dto;
using CeresStation.Model;

namespace CeresStation.Web.Extensions;

public static class ExtractorExtensions
{
    public static Extractor ToNewModel(this ExtractorDto dto, StationContext ctx) => new()
    {
        Id = Guid.NewGuid(),
        Name = dto.Name ?? string.Empty,
        Capacity = dto.Capacity ?? 0,
        Stockpile = dto.Stockpile ?? 0,
        ResourceId = dto.Resource?.Id ?? throw new InvalidOperationException("Must specify resource id"),
        Position = dto.Position ?? new Position(Position.Origin),
        ExtractionRate = dto.ExtractionRate ?? 0,
        StandardDeviation = dto.StandardDeviation ?? 0,
    };

    public static Extractor ToModel(this ExtractorDto dto, StationContext ctx)
    {
        Extractor extractor = ctx.Extractors.SingleOrDefault(e => e.Id == dto.Id) ?? throw new InvalidOperationException("Invalid extractor id.");
        // TODO
        return extractor;
    }
}