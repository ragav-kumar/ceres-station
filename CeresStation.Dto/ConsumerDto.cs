using CeresStation.Model;

namespace CeresStation.Dto;

public record ConsumerDto(
    Guid? Id,
    string? Name,
    PositionDto? Position,
    float? ConsumptionRate,
    float? StandardDeviation,
    float? Stockpile,
    float? Capacity,
    ResourceDto? Resource
);
