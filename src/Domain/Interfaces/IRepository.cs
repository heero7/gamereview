using Domain.Entities;

namespace Domain.Interfaces;

public interface IRepository<T> : IDisposable where T : Entity
{
    Task Add(T entity);
    Task<T> GetByUid(int id);
    Task<int> SaveChanges();
}