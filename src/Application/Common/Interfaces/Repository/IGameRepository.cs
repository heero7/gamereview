using Domain.Entities;

namespace Application.Common.Interfaces.Repository;

public interface IGameRepository : IRepository<Game>
{
    new Task<Game> GetById(int id);
    Task<IEnumerable<Game>> GetGamesByGenre(int categoryId);
}