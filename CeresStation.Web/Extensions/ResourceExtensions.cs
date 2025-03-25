using CeresStation.Dto;
using CeresStation.Model;

namespace CeresStation.Web;

internal static class ResourceExtensions
{
    internal static ResourceDto ToDto(this Resource resource) => new(
        Id: resource.Id,
        Name: resource.Name
    );
}