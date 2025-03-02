using System.Reflection;
using CeresStation.Model;

namespace CeresStation.Core;

public static class StationContextExtensions
{
    public static IQueryable GetQueryable(this StationContext ctx, string entityName)
    {
        Type? t = TypeHelper.GetType(entityName);
        if (t is null)
        {
            throw new TypeAccessException($"Type CeresStation.Model.{entityName} does not exist.");
        }

        MethodInfo method = typeof(StationContext)
            .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .First(m => m is { Name: "Set", IsGenericMethod: true } && m.GetParameters().Length == 0);

        MethodInfo genericMethod = method.MakeGenericMethod(t);
        return (IQueryable)(genericMethod.Invoke(ctx, []) ?? throw new InvalidOperationException());
    }
}
