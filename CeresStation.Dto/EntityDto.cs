using CeresStation.Model;

namespace CeresStation.Dto;

public record EntityDto(
    Guid? Id,
    string? Name,
    Position? Position
);