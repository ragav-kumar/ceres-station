using CeresStation.Dto;
using CeresStation.Model;

namespace CeresStation.Web;

internal static class PositionExtensions
{
    internal static PositionDto ToDto(this Position position) => new(position.X, position.Y, position.Z);

    internal static Position ToModel(this PositionDto dto) => new(dto.X, dto.Y, dto.Z);
}
