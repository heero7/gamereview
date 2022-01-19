using MediatR;

namespace Application.Reviews.Commands;

public class CreateReviewCommand : IRequest
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int Rating { get; set; }
    public string ReviewDescription { get; set; } = string.Empty;
    public int GameId { get; set; }
}

public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand>
{
    public Task<Unit> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        /*
         * ReviewService.AddReview(gameId, review);
         * 1. Validate review data
         * 2. Send id and review data to store in db
         * 3. Get id of review after success
         */
        throw new NotImplementedException();
    }
}