using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class GameReviewDbContext : DbContext
{
    public GameReviewDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Game> Games { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var properties = modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string)));
        foreach (var property in properties)
        {
            property.SetColumnType("varchar(150)");
        }

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameReviewDbContext).Assembly);

        var relationships = modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys());
        foreach (var relationship in relationships)
        {
            relationship.DeleteBehavior = DeleteBehavior.SetNull;
        }
        base.OnModelCreating(modelBuilder);
    }
}