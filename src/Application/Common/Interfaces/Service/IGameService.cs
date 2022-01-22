using Domain.Entities;

namespace Application.Common.Interfaces.Service;

public interface IGameService : IDisposable
{
    Task<Game> Add(Game game);
    Task<Game> GetById(int id);
    Task<Game> Update(Game game);
    Task<bool> Remove(Game game);
    Task<IEnumerable<Game>> GetGamesByCategory(int categoryId);
}