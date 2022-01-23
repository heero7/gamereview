using System.Linq.Expressions;
using Domain.Common;

namespace Application.Common.Interfaces.Repository;

public interface IRepository<TEntity> : IDisposable where TEntity : Entity
{
    Task Add(TEntity entity);
    Task<TEntity> GetById(int id);
    Task Update(TEntity entity);
    Task Remove(TEntity entity);
    Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> expression);
    Task<int> SaveChanges();
}