using CeresStation.Model;

namespace CeresStation.Dto;

public record TransportDto(
    Guid? Id,
    string? Name,
    Position? Position,
    float? TripTimeStandardDeviation,
    float? CurrentCargo,
    float? Capacity,
    EntityDto? Source,
    EntityDto? Destination,
    ResourceDto? Resource
);