using System.Collections.Concurrent;

namespace CeresStation.TickRunner;

public class TickRegistry
{
    private readonly ConcurrentDictionary<string, ITickable> _tickables = [];
    private string _connectionString;
    
    private static readonly Lazy<TickRegistry> instance = new(() => new TickRegistry());
    public static TickRegistry Instance => instance.Value;

    private TickRegistry()
    {
    }

    public static void Init(string connectionString)
    {
        instance.Value._connectionString = connectionString;
    }
    
    public void Register(ITickable tickable)
    {
        _tickables[tickable.Key] = tickable;
    }

    public void Unregister(ITickable tickable)
    {
        _tickables.Remove(tickable.Key, out _);
    }
    
    public IEnumerable<ITickable> Snapshot() => _tickables.Values;
}
