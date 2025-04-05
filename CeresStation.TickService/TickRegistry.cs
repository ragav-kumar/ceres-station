namespace CeresStation.TickService;

public class TickRegistry
{
    private readonly List<ITickable> _tickables = [];
    private readonly Lock _lock = new();
    
    public void Register(ITickable tickable)
    {
        lock (_lock)
        {
            _tickables.Add(tickable);
        }
    }

    public void Unregister(ITickable tickable)
    {
        lock (_lock)
        {
            _tickables.Remove(tickable);
        }
    }

    public List<ITickable> Snapshot()
    {
        lock (_lock)
        {
            return _tickables.ToList();
        }
    }
}
