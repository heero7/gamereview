using Domain.Entities;

namespace Application.Common.Interfaces.Repository;

public interface IReviewRepository : IRepository<Review>
{
    new Task<Review> GetById(int id);
    Task<IEnumerable<Review>> GetReviewsByGame(int gameId);
}