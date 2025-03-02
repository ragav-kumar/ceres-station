using CeresStation.Model;
using Microsoft.EntityFrameworkCore;

namespace CeresStation.Core;

public class StationContext : DbContext
{
    public DbSet<Extractor> Extractors { get; set; }
    public DbSet<Resource> Resources { get; set; }
    public DbSet<EntityAttribute> Attributes { get; set; }
    public DbSet<EntityAttributeDefinition> AttributeDefinitions { get; set; }
    public DbSet<Column> Columns { get; set; }
    public DbSet<Processor> Processors { get; set; }
    public DbSet<Reagent> Reagents { get; set; }

    public string DbPath { get; set; }

    public StationContext()
    {
        Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
        string path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "CeresStation.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
