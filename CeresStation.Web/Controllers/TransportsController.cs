﻿using AutoMapper;
using CeresStation.Core;
using CeresStation.Dto;
using CeresStation.Model;
using Microsoft.AspNetCore.Mvc;

namespace CeresStation.Web.Controllers;

[Route("api/[controller]")]
public class TransportsController(IMapper mapper) : CrudController<Transport, TransportDto>(mapper)
{
    protected override Transport NewModel() => new()
    {
        Id = Guid.NewGuid(),
        Name = "New Transport",
        Position = Position.Origin,
        Capacity = 0,
        CurrentCargo = 0,
        TripTimeStandardDeviation = 0,
        SourceId = Guid.Empty,
        DestinationId = Guid.Empty,
        ResourceId = Guid.Empty,
    };

    protected override void ApplyDto(Transport model, TransportDto dto, StationContext ctx)
    {
        if (dto.Name is not null)
            model.Name = dto.Name;
        if (dto.Position is not null)
            model.Position = dto.Position;
        if (dto.Capacity is not null)
            model.Capacity = dto.Capacity.Value;
        if (dto.TripTimeStandardDeviation is not null)
            model.TripTimeStandardDeviation = dto.TripTimeStandardDeviation.Value;
        if (dto.CurrentCargo is not null)
            model.CurrentCargo = dto.CurrentCargo.Value;
        if (dto.Source?.Id is not null)
            model.SourceId = dto.Source.Id.Value;
        if (dto.Destination?.Id is not null)
            model.DestinationId = dto.Destination.Id.Value;
        if (dto.Resource is not null)
            model.ResourceId = dto.Resource.Id;
    }

    protected override Guid GetId(Transport model) => model.Id;

    protected override Transport? GetFromId(StationContext ctx, Guid id) => ctx.Transports.SingleOrDefault(t => t.Id == id);
}