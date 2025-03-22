namespace CeresStation.Dto;

public record ListDataDto(
    List<ListRowDto> Rows,
    int TotalCount
);
