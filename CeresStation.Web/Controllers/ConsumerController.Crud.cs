﻿using CeresStation.Context;
using CeresStation.Dto;
using CeresStation.Model;

namespace CeresStation.Web;

public partial class ConsumerController
{
    protected override Consumer NewModel() => new()
    {
        Id = Guid.NewGuid(),
        Name = "New Consumer",
        Position = Position.Origin,
        Capacity = 0,
        Stockpile = 0,
        ConsumptionRate = 0,
        StandardDeviation = 0,
        ResourceId = Guid.Empty
    };

    protected override void ApplyDto(Consumer model, ConsumerDto dto, StationContext _)
    {
        if (dto.Name is not null)
            model.Name = dto.Name;
        if (dto.Position is not null)
            model.Position = dto.Position.ToModel();
        if (dto.Capacity is not null)
            model.Capacity = dto.Capacity.Value;
        if (dto.Stockpile is not null)
            model.Stockpile = dto.Stockpile.Value;
        if (dto.ConsumptionRate is not null)
            model.ConsumptionRate = dto.ConsumptionRate.Value;
        if (dto.StandardDeviation is not null)
            model.StandardDeviation = dto.StandardDeviation.Value;
        if (dto.Resource?.Id is not null)
            model.ResourceId = dto.Resource.Id;
    }

    protected override Guid GetId(Consumer model) => model.Id;
    protected override Consumer? GetFromId(StationContext ctx, Guid id) => ctx.Consumers.SingleOrDefault(x => x.Id == id);

    protected override ConsumerDto ToDto(Consumer model) => new(
        Id: model.Id,
        Name: model.Name,
        Position: model.Position.ToDto(),
        ConsumptionRate: model.ConsumptionRate,
        StandardDeviation: model.StandardDeviation,
        Stockpile: model.Stockpile,
        Capacity: model.Capacity,
        Resource: model.Resource.ToDto()
    );
}
