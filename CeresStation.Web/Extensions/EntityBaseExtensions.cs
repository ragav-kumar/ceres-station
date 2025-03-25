using CeresStation.Dto;
using CeresStation.Model;

namespace CeresStation.Web;

public static class EntityBaseExtensions
{
    public static EntityDto ToDto(this EntityBase entity) => new(
        Id: entity.Id,
        Name: entity.Name,
        Position: entity.Position
    );
}