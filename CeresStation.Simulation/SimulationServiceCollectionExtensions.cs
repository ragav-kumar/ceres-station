using CeresStation.TickService;
using Microsoft.Extensions.DependencyInjection;

namespace CeresStation.Simulation;

public static class SimulationServiceCollectionExtensions
{
    public static IServiceCollection AddSimulation(this IServiceCollection services)
    {
        services.RegisterSimulation<ExtractorSimulation>();
        
        return services;
    }

    private static void RegisterSimulation<T>(this IServiceCollection services) where T : class, ITickable
    {
        // services.AddScoped<T>();
        services.AddScoped<ITickable, T>();/*sp =>
        {
            var simulation = sp.GetRequiredService<T>();
            var registry = sp.GetRequiredService<TickRegistry>();
            registry.Register(simulation);
            return simulation;
        });*/
    }
}
