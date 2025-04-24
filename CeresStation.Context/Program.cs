using CeresStation.Context;
using CeresStation.Context.Init;

string dbPath = args.FirstOrDefault() ?? $"Data Source={Path.Combine(AppContext.BaseDirectory, @"..\..\..\..\CeresStation.db")}";

await using StationContext ctx = new(dbPath);

Console.WriteLine($"Database path: {dbPath}");

// Initialize
DatabaseInitializer initialize = new(ctx);

Console.WriteLine("Begin Database initialization.");
Console.WriteLine("---------------------------------");
Console.WriteLine("Deleting old database...");
await ctx.Database.EnsureDeletedAsync();
Console.WriteLine("Recreating database...");
await ctx.Database.EnsureCreatedAsync();

Console.WriteLine();
Console.WriteLine("Initializing settings...");
await initialize.Settings();
Console.WriteLine();
Console.WriteLine("Initializing resources...");
await initialize.Resources();
Console.WriteLine();
Console.WriteLine("Initializing extractors...");
await initialize.Extractors();
Console.WriteLine();
Console.WriteLine("Initializing processors...");
await initialize.Processors();
Console.WriteLine();
Console.WriteLine("Initializing consumers...");
await initialize.Consumers();
Console.WriteLine();
Console.WriteLine("Initializing transport routes...");
await initialize.TransportRoutes();
Console.WriteLine();
Console.WriteLine("Initializing transports...");
await initialize.Transports();

Console.WriteLine();
Console.WriteLine("Database initialization complete.");
