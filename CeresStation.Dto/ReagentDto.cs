namespace CeresStation.Dto;

public record ReagentDto(
    Guid? Id,
    ResourceDto? Resource,
    float? Count,
    float? StockpileCapacity
);