using Application.Common.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class GameRepository : Repository<Game>, IGameRepository
{
    public GameRepository(GameReviewDbContext gameReviewDbContext) : base(gameReviewDbContext)
    {
    }

    public override async Task<Game> GetById(int id)
    {
        return (await Db.Games
            .AsNoTracking()
            .Include(g => g.GenreId)
            .Where(g => g.Id == id)
            .FirstOrDefaultAsync())!; // Allow for nulls.
    }

    public async Task<IEnumerable<Game>> GetGamesByGenre(int categoryId) 
        => await Search(g => g.GenreId == categoryId);
}