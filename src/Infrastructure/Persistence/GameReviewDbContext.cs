using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class GameReviewDbContext : DbContext, IGameReviewDbContext
{
    public GameReviewDbContext(DbContextOptions<GameReviewDbContext> options) : base(options)
    {
    }

    public DbSet<Game> Games { get; }
    public DbSet<Review> Reviews { get; }
    public DbSet<Genre> Genres { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var columnsThatAreVarchar = modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string)));
        foreach (var property in columnsThatAreVarchar)
        {
            property.SetColumnType("varchar(150)");
        }

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameReviewDbContext).Assembly);

        var mutableForeignKeys = modelBuilder.Model.GetEntityTypes().SelectMany(e =>  e.GetForeignKeys());
        foreach (var relationship in mutableForeignKeys)
        {
            relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
        }
        
        base.OnModelCreating(modelBuilder);
    }


    public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}