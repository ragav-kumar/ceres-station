namespace CeresStation.TickRunner;

public interface ITickable
{
    public string Key { get; }
    public Task TickAsync(string connectionString, CancellationToken cancellationToken);
}
