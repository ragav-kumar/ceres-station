namespace CeresStation.Dto;

public record ExtractorDto(
	Guid? Id,
	string? Name,
	PositionDto? Position,
	float? ExtractionRate,
	float? StandardDeviation,
	float? Stockpile,
	float? Capacity,
	ResourceDto? Resource
);
