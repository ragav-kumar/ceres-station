using CeresStation.Context;
using CeresStation.Model;

namespace CeresStation.Simulation;

internal static class StationContextExtensions
{
    internal static List<Transport> GetTransportsAtEntity(this StationContext ctx, EntityBase entity) => ctx
        .Transports
        .Where(o => o.Position == entity.Position)
        .ToList();
}
