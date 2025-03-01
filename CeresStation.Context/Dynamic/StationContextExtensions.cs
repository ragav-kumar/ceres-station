using System.Reflection;

namespace CeresStation.Core;

public static class StationContextExtensions
{
    public static IQueryable GetQueryable(this StationContext ctx, string entityName)
    {
        Type? t = Type.GetType($"CeresStation.Models.{entityName}");
        if (t is null)
        {
            throw new TypeAccessException($"Type CeresStation.Models.{entityName} does not exist.");
        }

        MethodInfo? method = typeof(StationContext).GetMethod("Set", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        if (method is null)
        {
            throw new TypeAccessException($"Cannot access StationContext.Set()");
        }

        MethodInfo genericMethod = method.MakeGenericMethod(t);
        return (IQueryable)(genericMethod.Invoke(ctx, []) ?? throw new InvalidOperationException());
    }
}
