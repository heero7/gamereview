using Application.Common.Interfaces.Repository;
using Application.Common.Interfaces.Service;
using Domain.Entities;

namespace Infrastructure.Service;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;
    
    public GameService(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }
    
    public void Dispose()
    {
        _gameRepository.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task<Game> Add(Game game)
    {
        // Validate that this game already doesn't exist with a similar name.
        await _gameRepository.Add(game);
        return game;
    }

    public async Task<Game> GetById(int id) => await _gameRepository.GetById(id);

    public async Task<Game> Update(Game game)
    {
        // Validate that this game exists before updating.
        await _gameRepository.Update(game);
        return game;
    }

    public async Task<bool> Remove(Game game)
    {
        // If the game doesn't exist, return false.
        await _gameRepository.Remove(game);
        return true;
    }

    public async Task<IEnumerable<Game>> GetGamesByCategory(int categoryId) 
        => await _gameRepository.GetGamesByGenre(categoryId);
}