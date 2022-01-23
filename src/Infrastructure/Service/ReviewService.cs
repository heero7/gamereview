using Application.Common.Interfaces.Repository;
using Application.Common.Interfaces.Service;
using Domain.Entities;

namespace Infrastructure.Service;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;
    
    public ReviewService(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }
    
    public void Dispose()
    {
        _reviewRepository.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task<Review> Add(Review review)
    {
        await _reviewRepository.Add(review);
        return review;
    }

    public async Task<Review> GetById(int id) => await _reviewRepository.GetById(id);

    public async Task<Review> Update(Review review)
    {
        // Validate that this review exists first.
        await _reviewRepository.Update(review);
        return review;
    }

    public async Task<bool> Remove(Review review)
    {
        await _reviewRepository.Remove(review);
        return true;
    }
}