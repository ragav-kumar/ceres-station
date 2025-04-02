using CeresStation.Model;

namespace CeresStation.Dto;

public record ProcessorDto(
    Guid? Id,
    string? Name,
    PositionDto? Position,
    float? TimeStep,
    IList<ReagentDto>? Inputs,
    IList<ReagentDto>? Outputs
);
