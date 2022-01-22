using Application.Common.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repository;

public class GenreRepository : Repository<Genre>, IGenreRepository
{
    public GenreRepository(GameReviewDbContext gameReviewDbContext) : base(gameReviewDbContext)
    {
    }
}