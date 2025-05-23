﻿using CeresStation.Context;
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
            model.Position = dto.Position.ToModel();
        if (dto.ExtractionRate is not null)
            model.ExtractionRate = dto.ExtractionRate.Value;
        if (dto.StandardDeviation is not null)
            model.StandardDeviation = dto.StandardDeviation.Value;
    }

    protected override Guid GetId(Extractor model) => model.Id;

    protected override Extractor? GetFromId(StationContext ctx, Guid id) => ctx.Extractors.SingleOrDefault(e => e.Id == id);

    protected override ExtractorDto ToDto(Extractor model) => new(
        Id: model.Id,
        Name: model.Name,
        Position: model.Position.ToDto(),
        ExtractionRate: model.ExtractionRate,
        StandardDeviation: model.StandardDeviation,
        Stockpile: model.Stockpile,
        Capacity: model.Capacity,
        Resource: model.Resource?.ToDto() ?? null
    );
}
