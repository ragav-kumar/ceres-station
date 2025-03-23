using CeresStation.Core;
using CeresStation.Core.Init;

await using StationContext ctx = new();

Console.WriteLine($"Database path: {ctx.DbPath}");

// Initialize
DatabaseInitializer initialize = new(ctx);

Console.WriteLine("Begin Database initialization.");
Console.WriteLine("---------------------------------");
Console.WriteLine("Deleting old database...");
await ctx.Database.EnsureDeletedAsync();
Console.WriteLine("Recreating database...");
await ctx.Database.EnsureCreatedAsync();

Console.WriteLine("Initializing settings...");
await initialize.Settings();
Console.WriteLine("Initializing resources...");
await initialize.Resources();
Console.WriteLine("Initializing extractors...");
await initialize.Extractors();
Console.WriteLine("Initializing processors...");
await initialize.Processors();
Console.WriteLine("Initializing consumers...");
await initialize.Consumers();
Console.WriteLine("Initializing transports...");
await initialize.Transports();

Console.WriteLine("Database initialization complete.");
