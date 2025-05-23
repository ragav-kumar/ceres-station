﻿using CeresStation.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CeresStation.Context;

public class StationContext : DbContext
{
    public DbSet<Extractor> Extractors => Set<Extractor>();
    public DbSet<Resource> Resources => Set<Resource>();
    public DbSet<EntityAttribute> Attributes => Set<EntityAttribute>();
    public DbSet<EntityAttributeDefinition> AttributeDefinitions => Set<EntityAttributeDefinition>();
    public DbSet<Column> Columns => Set<Column>();
    public DbSet<Processor> Processors => Set<Processor>();
    public DbSet<Reagent> Reagents => Set<Reagent>();
    public DbSet<Consumer> Consumers => Set<Consumer>();
    public DbSet<Transport> Transports => Set<Transport>();
    public DbSet<EntityBase> Entities => Set<EntityBase>();
    public DbSet<GeneralSetting> Settings => Set<GeneralSetting>();
    public DbSet<TransportRoute> TransportRoutes => Set<TransportRoute>();

    private readonly string? _connectionString;

    // For ASP.NET Core DI
    public StationContext(DbContextOptions<StationContext> options)
        : base(options)
    {
    }
    
    // For usage from console
    public StationContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured && _connectionString is not null)
        {
            options
                .UseSqlite(_connectionString, o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
                .UseLazyLoadingProxies()
                .ConfigureWarnings(w => w.Throw(RelationalEventId.MultipleCollectionIncludeWarning));
            //.EnableSensitiveDataLogging();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StationContext).Assembly);
    }
    
    public void Detach<TEntity>(TEntity entity) where TEntity : class
    {
        EntityEntry<TEntity> entry = Entry(entity);
        if (entry.State != EntityState.Detached)
        {
            entry.State = EntityState.Detached;
        }
    }
}
