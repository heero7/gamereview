using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public abstract class Repository<T> : IRepository<T> where T : Entity
{
    protected readonly GameReviewDbContext _dbContext;
    protected readonly DbSet<T> _dbSet;

    protected Repository(GameReviewDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<T>();
    }

    public virtual async Task Add(T entity)
    {
        _dbSet.Add(entity);
        await SaveChanges();
    }

    public virtual async Task<T> GetByUid(int id)
    {
        return (await _dbSet.FindAsync(id))!; // Suppress possible null, we're okay with a null value.
    }

    public Task<int> SaveChanges()
    {
        throw new NotImplementedException();
    }
    
    public void Dispose()
    {
        throw new NotImplementedException();
    }
}