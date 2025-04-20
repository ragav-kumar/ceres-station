using System.CommandLine;
using CeresStation.Simulation;
using CeresStation.TickRunner;

const string mutexName = "Global\\CERES_STATION_TICK_SERVICE";
using var mutex = new Mutex(true, mutexName, out bool createdNew);

if (!createdNew)
{
    // Another instance is already running.
    return;
}

Option<string> connectionStringOption = new(
    "--ConnectionString",
    "Database connection string"
)
{
    IsRequired = true
};

RootCommand rootCommand = [connectionStringOption];
rootCommand.Description = "Ceres Station Tick Runner";
rootCommand.SetHandler(connectionString =>
{
    TickRegistry.Init(connectionString);
    foreach (ISimulation simulation in SimulationExtensions.Simulations)
    {
        TickRegistry.Instance.Register(simulation);
    }
}, connectionStringOption);

await rootCommand.InvokeAsync(args);

using CancellationTokenSource tokenSource = new();
Console.CancelKeyPress += (_, eventArgs) =>
{
    Console.WriteLine("Shutting down...");
    eventArgs.Cancel = true;
    // ReSharper disable once AccessToDisposedClosure
    tokenSource.Cancel();
};

Console.WriteLine("TickRunner started. Press Ctrl+C to exit.");

TickService tickService = new();
try
{
    await tickService.RunAsync(tokenSource.Token);
}
catch (TaskCanceledException)
{
    Console.WriteLine("TickRunner stopped.");
}
finally
{
    mutex.ReleaseMutex();
}
