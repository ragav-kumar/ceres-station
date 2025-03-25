using CeresStation.Dto;
using CeresStation.Model;

namespace CeresStation.Web;

public static class ReagentExtensions
{
    public static ReagentDto ToDto(this Reagent reagent) => new(
        Id: reagent.Id,
        Resource: reagent.Resource.ToDto(),
        Count: reagent.Count,
        StockpileCapacity: reagent.StockpileCapacity
    );
    
    public static IEnumerable<ReagentDto> ToDto(this IEnumerable<Reagent> reagents) => reagents.Select(ToDto);
}