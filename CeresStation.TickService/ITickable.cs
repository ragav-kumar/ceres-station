namespace CeresStation.TickService;

public interface ITickable
{
    public Task TickAsync(CancellationToken cancellationToken);
}
