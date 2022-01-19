using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Repositories;

public class GameRepository : Repository<Game>
{
    public GameRepository(GameReviewDbContext dbContext) : base(dbContext)
    {
    }
}