using CeresStation.Model;

namespace CeresStation.Dto;

public record ExtractorDto(
	Guid? Id,
	string? Name,
	Position? Position,
	float? ExtractionRate,
	float? StandardDeviation,
	float? Stockpile,
	float? Capacity,
	ResourceDto? Resource
);
