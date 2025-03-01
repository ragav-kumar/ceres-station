using CeresStation.Model;

namespace CeresStation.Dto;

public record ColumnDto(
	Guid Id,
	EntityType EntityType,
	string? DisplayName,
	Guid? AttributeDefinitionId,
	string? FieldName,
	int Width,
	int Order
);
