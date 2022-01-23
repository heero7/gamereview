using Application.Common.Interfaces.Service;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Reviews.Commands;

public class CreateReviewCommand : IRequest<int>
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int Rating { get; set; }
    public string ReviewDescription { get; set; } = string.Empty;
    public int GameId { get; set; }
}

public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, int>
{
    private IReviewService _reviewService;
    private IMapper _mapper;

    public CreateReviewCommandHandler(IReviewService reviewService, IMapper mapper)
    {
        _reviewService = reviewService;
        _mapper = mapper;
    }
    
    public async Task<int> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var review = _mapper.Map<Review>(request);
        var createdReview = await _reviewService.Add(review);
        return createdReview.Id;
    }
}