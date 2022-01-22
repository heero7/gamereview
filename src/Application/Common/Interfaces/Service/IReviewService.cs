using Domain.Entities;

namespace Application.Common.Interfaces.Service;

public interface IReviewService : IDisposable
{
    Task<Review> Add(Review review);
    Task<Review> GetById(int id);
    Task<Review> Update(Review review); // TODO: Need the whole object?
    Task<bool> Remove(Review review);
}