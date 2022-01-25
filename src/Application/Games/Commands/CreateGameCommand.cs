using Application.Common.Interfaces.Service;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Games.Commands;

public class CreateGameCommand : IRequest<int>
{
    public string Name { get; set; }
    public int GenreId { get; set; }
    public DateOnly ReleaseDate { get; set; }
}

public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, int>
{
    private IGameService _gameService;
    private readonly IMapper _mapper;

    public CreateGameCommandHandler(IGameService gameService, IMapper mapper)
    {
        _gameService = gameService;
        _mapper = mapper;
    }
    
    public async Task<int> Handle(CreateGameCommand request, CancellationToken cancellationToken)
    {
        var game = _mapper.Map<Game>(request);
        var addedGame = await _gameService.Add(game);
        return addedGame.Id;
    }
}