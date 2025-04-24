using CeresStation.Context;
using CeresStation.Dto;
using CeresStation.Model;

namespace CeresStation.Web;

public partial class TransportsController
{
    protected override Transport NewModel() => new()
    {
        Id = Guid.NewGuid(),
        Name = "New Transport",
        Position = Position.Origin,
        Capacity = 0,
        Stockpile = 0,
        StandardDeviation = 0,
        Acceleration = 0f,
        RouteId = Guid.Empty,
        CargoTypeId = Guid.Empty,
        NextWaypointIndex = 0,
    };

    protected override void ApplyDto(Transport model, TransportDto dto, StationContext ctx)
    {
        if (dto.Name is not null)
            model.Name = dto.Name;
        if (dto.Position is not null)
            model.Position = dto.Position.ToModel();
        if (dto.Capacity is not null)
            model.Capacity = dto.Capacity.Value;
        if (dto.StandardDeviation is not null)
            model.StandardDeviation = dto.StandardDeviation.Value;
        if (dto.Stockpile is not null)
            model.Stockpile = dto.Stockpile.Value;
        if (dto.CargoType is not null)
            model.CargoTypeId = dto.CargoType.Id;
        if (dto.NextWaypointIndex is not null)
            model.NextWaypointIndex = dto.NextWaypointIndex.Value;
        if (dto.Route?.Id != null)
            model.RouteId = dto.Route.Id.Value;
        if (dto.Acceleration is not null)
            model.Acceleration = dto.Acceleration.Value;
    }

    protected override Guid GetId(Transport model) => model.Id;
    protected override Transport? GetFromId(StationContext ctx, Guid id) => ctx.Transports.SingleOrDefault(t => t.Id == id);

    protected override TransportDto ToDto(Transport model) => new(
        Id: model.Id,
        Name: model.Name,
        Position: model.Position.ToDto(),
        StandardDeviation: model.StandardDeviation,
        Stockpile: model.Stockpile,
        Capacity: model.Capacity,
        CargoType: model.CargoType?.ToDto(),
        NextWaypointIndex: model.NextWaypointIndex,
        Acceleration: model.Acceleration,
        Route: model.Route.ToDto()
    );
}
