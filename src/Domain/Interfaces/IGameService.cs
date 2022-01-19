using Domain.Entities;

namespace Domain.Interfaces;

public interface IGameService
{
    void AddGame(Game game);
    Game GetGameById(int id);
}