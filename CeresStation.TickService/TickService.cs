﻿using System.Diagnostics;
using Microsoft.Extensions.Hosting;

namespace CeresStation.TickService;

public class TickService : BackgroundService
{
    private readonly TimeSpan _tickDuration = TimeSpan.FromSeconds(1);
    private readonly TickRegistry _tickRegistry;

    public TickService(TickRegistry registry)
    {
        _tickRegistry = registry;
    }

    protected override async Task ExecuteAsync(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            long start = Stopwatch.GetTimestamp();

            await Tick(token);

            long elapsed = Stopwatch.GetTimestamp() - start;
            long elapseMilliseconds = elapsed * 1000 / Stopwatch.Frequency;
            long remaining = Math.Max(0, _tickDuration.Milliseconds - elapseMilliseconds);

            await Task.Delay(TimeSpan.FromMilliseconds(remaining), token);
        }
    }

    private async Task Tick(CancellationToken cancellationToken)
    {
        List<ITickable> snapshot = _tickRegistry.Snapshot();
        IEnumerable<Task> tasks = snapshot.Select(o => o.TickAsync(cancellationToken));
        await Task.WhenAll(tasks);
    }
}
