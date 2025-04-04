using CeresStation.Dto;
using CeresStation.Model;

namespace CeresStation.Web;

internal static class ReagentExtensions
{
    internal static ReagentDto ToDto(this Reagent reagent) => new(
        Id: reagent.Id,
        Resource: reagent.Resource.ToDto(),
        Count: reagent.Count,
        StockpileCapacity: reagent.StockpileCapacity
    );
    
    internal static IEnumerable<ReagentDto> ToDto(this IEnumerable<Reagent> reagents) => reagents.Select(ToDto);
}
