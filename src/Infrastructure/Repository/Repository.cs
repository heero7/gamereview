using System.Linq.Expressions;
using Application.Common.Interfaces.Repository;
using Domain.Common;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    protected readonly GameReviewDbContext Db;
    protected readonly DbSet<TEntity> DbSet;

    protected Repository(GameReviewDbContext gameReviewDbContext)
    {
        Db = gameReviewDbContext;
        DbSet = gameReviewDbContext.Set<TEntity>();
    }

    public void Dispose()
    {
        Db.Dispose();
        GC.SuppressFinalize(this);
    }

    public virtual async Task Add(TEntity entity)
    {
        DbSet.Add(entity);
        await SaveChanges();
    }

    public virtual async Task<TEntity> GetById(int id) 
        => (await DbSet.FindAsync(id))!; // Suppress null warning, its okay.

    public virtual async Task Update(TEntity entity)
    {
        DbSet.Update(entity);
        await SaveChanges();
    }

    public virtual async Task Remove(TEntity entity)
    {
        DbSet.Remove(entity);
        await SaveChanges();
    }

    public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> expression) 
        => await DbSet.AsNoTracking().Where(expression).ToListAsync();

    public async Task<int> SaveChanges() => await Db.SaveChangesAsync();
}