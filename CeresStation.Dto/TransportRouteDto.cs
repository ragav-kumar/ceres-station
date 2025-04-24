namespace CeresStation.Dto;

public record TransportRouteDto(
    Guid? Id,
    string? Name,
    List<EntityDto> Waypoints
);
