using Application.Common.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repository;

public class ReviewRepository : Repository<Review>, IReviewRepository
{
    public ReviewRepository(GameReviewDbContext gameReviewDbContext) : base(gameReviewDbContext)
    {
    }

    public async Task<IEnumerable<Review>> GetReviewsByGame(int gameId) 
        => await Search(r => r.GameId == gameId);
}