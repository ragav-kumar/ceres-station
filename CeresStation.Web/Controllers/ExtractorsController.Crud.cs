using CeresStation.Core;
using CeresStation.Dto;
using CeresStation.Model;

namespace CeresStation.Web;

public partial class ExtractorsController
{
    protected override Extractor NewModel() => new()
    {
        Id = Guid.NewGuid(),
        Name = "New Extractor",
        Capacity = 0,
        Stockpile = 0,
        ResourceId = Guid.Empty,
        Position = Position.Origin,
        ExtractionRate = 0,
        StandardDeviation = 0,
    };

    protected override void ApplyDto(Extractor model, ExtractorDto dto, StationContext _)
    {
        // Intentionally skip dto.Id.

        if (dto.Name is not null)
            model.Name = dto.Name;
        if (dto.Capacity is not null)
            model.Capacity = dto.Capacity.Value;
        if (dto.Stockpile is not null)
            model.Stockpile = dto.Stockpile.Value;
        if (dto.Resource is not null)
            model.ResourceId = dto.Resource.Id;
        if (dto.Position is not null)
            model.Position = new Position(dto.Position);
        if (dto.ExtractionRate is not null)
            model.ExtractionRate = dto.ExtractionRate.Value;
        if (dto.StandardDeviation is not null)
            model.StandardDeviation = dto.StandardDeviation.Value;
    }

    protected override Guid GetId(Extractor model) => model.Id;

    protected override Extractor? GetFromId(StationContext ctx, Guid id) => ctx.Extractors.SingleOrDefault(e => e.Id == id);
}