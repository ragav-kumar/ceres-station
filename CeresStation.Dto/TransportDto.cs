namespace CeresStation.Dto;

public record TransportDto(
    Guid? Id,
    string? Name,
    PositionDto? Position,
    float? Acceleration,
    float? StandardDeviation,
    float? Stockpile,
    float? Capacity,
    TransportRouteDto? Route,
    ResourceDto? CargoType,
    int? NextWaypointIndex
);
