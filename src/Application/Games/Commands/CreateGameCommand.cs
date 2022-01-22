using Application.Common.Interfaces.Service;
using Domain.Entities;
using MediatR;

namespace Application.Games.Commands;

public class CreateGameCommand : IRequest<int>
{
    public string Name { get; set; }
    public int GenreId { get; set; }
    public DateTime ReleaseDate { get; set; }
}

public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, int>
{
    private IGameService _gameService;

    public CreateGameCommandHandler(IGameService gameService)
    {
        _gameService = gameService;
    }
    
    public async Task<int> Handle(CreateGameCommand request, CancellationToken cancellationToken)
    {
        var game = new Game
        {
            Name = request.Name,
            GenreId = request.GenreId,
            ReleaseDate = request.ReleaseDate
        };
        
        var addedGame = await _gameService.Add(game);
        return addedGame.Id;
    }
}