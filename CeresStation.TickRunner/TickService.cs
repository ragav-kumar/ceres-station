using System.Diagnostics;

namespace CeresStation.TickRunner;

public class TickService
{
    private readonly TimeSpan _tickDuration = TimeSpan.FromSeconds(1);

    public async Task RunAsync(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            long start = Stopwatch.GetTimestamp();

            // tick simulations from registry
            await TickRegistry.Instance.TickAllSimulationsAsync(token);

            long elapsed = Stopwatch.GetTimestamp() - start;
            double elapseMilliseconds = elapsed * 1000.0 / Stopwatch.Frequency;
            var remaining = (long)Math.Max(0, _tickDuration.TotalMilliseconds - elapseMilliseconds);

            await Task.Delay(TimeSpan.FromMilliseconds(remaining), token);
        }
    }
}
