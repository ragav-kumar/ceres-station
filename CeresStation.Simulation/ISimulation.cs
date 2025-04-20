namespace CeresStation.Simulation;

public interface ISimulation
{
    public string Key { get; }
    public Task TickAsync(string connectionString, CancellationToken cancellationToken);
}
