using System.Reflection;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CeresStation.GraphQl;

public static class GraphQlRegistration
{
    public static IRequestExecutorBuilder AddCeresStationGraphQl(this IRequestExecutorBuilder builder)
    {
        return builder
            .AddQueryType(d => d.Name("Query"))
            .AddMutationType(d => d.Name("Mutation"))
            .AddFiltering()
            .AddSorting()
            .AddProjections()
            .AddTypesFromAssembly(typeof(GraphQlRegistration).Assembly);
    }
    
    private static IRequestExecutorBuilder AddTypesFromAssembly(this IRequestExecutorBuilder builder, Assembly assembly)
    {
        IEnumerable<Type> types = assembly.GetTypes()
            .Where(t =>
                t is { IsAbstract: false, IsClass: true, IsGenericTypeDefinition: false, IsPublic: true }
                && typeof(IType).IsAssignableFrom(t)
            );

        foreach (Type type in types)
        {
            builder = builder.AddType(type);
        }

        return builder;
    }
}
