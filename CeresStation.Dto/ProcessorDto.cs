using CeresStation.Model;

namespace CeresStation.Dto;

public record ProcessorDto(
    Guid? Id,
    string? Name,
    Position? Position,
    float? TimeStep,
    IList<ReagentDto>? Inputs,
    IList<ReagentDto>? Outputs
);