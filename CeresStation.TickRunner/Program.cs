using CeresStation.TickRunner;

const string mutexName = "Global\\CERES_STATION_TICK_SERVICE";
using var mutex = new Mutex(true, mutexName, out bool createdNew);

if (!createdNew)
{
    // Another instance is already running.
    return;
}

string GetNamedArgument(string name)
{
    var prefix = $"--{name}=";
    return args
        .Where(arg => arg.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
        .Select(arg => arg.Substring(prefix.Length))
        .FirstOrDefault()
        ?? throw new ArgumentNullException(name, $"The argument '{name}' was not found.");
}

if (args.Length < 1 || string.IsNullOrWhiteSpace(args[0]))
{
    throw new ArgumentException("Must specify connection string with '-ConnectionString <connection string>'.");
}

string connectionString = GetNamedArgument("ConnectionString");
TickRegistry.Init(connectionString);

using var tokenSource = new CancellationTokenSource();

Console.CancelKeyPress += (_, eventArgs) =>
{
    Console.WriteLine("Shutting down...");
    eventArgs.Cancel = true;
    tokenSource.Cancel();
};



Console.WriteLine("TickRunner started. Press Ctrl+C to exit.");

await tickService.RunAsync(tokenSource.Token);

Console.WriteLine("TickRunner stopped.");

mutex.ReleaseMutex();
