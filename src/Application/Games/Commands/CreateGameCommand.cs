using MediatR;

namespace Application.Games.Commands;

public class CreateGameCommand : IRequest<int>
{
    public string Name { get; set; }
}

public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, int>
{
    public Task<int> Handle(CreateGameCommand request, CancellationToken cancellationToken)
    {
        /*
         * GameService.AddGame();
         * 1. Validate Game information (whatever that is)
         * 2. Add to database list of games
         * 3. Return the id of the entity created
         */
        throw new NotImplementedException();
    }
}