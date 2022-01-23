using Domain.Entities;

namespace Application.Common.Interfaces.Service;

public interface IReviewService : IDisposable
{
    Task<Review> Add(Review review);
    Task<Review> GetById(int id);
    Task<Review> Update(Review review);
    Task<bool> Remove(Review review);
}