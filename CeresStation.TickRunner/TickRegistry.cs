using System.Collections.Concurrent;
using CeresStation.Simulation;

namespace CeresStation.TickRunner;

public class TickRegistry
{
    private readonly ConcurrentDictionary<string, ISimulation> _simulations = [];
    private string _connectionString = string.Empty;
    
    private static readonly Lazy<TickRegistry> instance = new(() => new TickRegistry());
    public static TickRegistry Instance => instance.Value;

    private TickRegistry()
    {
    }

    public static void Init(string connectionString)
    {
        instance.Value._connectionString = connectionString;
    }
    
    public void Register(ISimulation simulation)
    {
        _simulations[simulation.Key] = simulation;
    }

    public void Unregister(ISimulation simulation)
    {
        _simulations.Remove(simulation.Key, out _);
    }

    public async Task TickAllSimulationsAsync(CancellationToken cancellationToken)
    {
        IEnumerable<ISimulation> snapshot = _simulations.Values;
        IEnumerable<Task> tasks = snapshot.Select(o => o.TickAsync(_connectionString, cancellationToken));
        await Task.WhenAll(tasks);
    }
}
