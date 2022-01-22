using Application.Common.Interfaces.Service;
using AutoMapper;
using MediatR;

namespace Application.Games.Queries;

public class GameViewModel
{
    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int GenreId { get; set; }
    public string Genre { get; set; }
}

public class GetGameByIdQuery : IRequest<GameViewModel>
{
    public int Id { get; set; }
}

public class GetGameByIdQueryHandler : IRequestHandler<GetGameByIdQuery, GameViewModel>
{
    private IGameService _gameService;
    private IMapper _mapper;

    public GetGameByIdQueryHandler(IGameService gameService, IMapper mapper)
    {
        _gameService = gameService;
        _mapper = mapper;
    }
    
    public async Task<GameViewModel> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
    {
        var game = await _gameService.GetById(request.Id);
        return _mapper.Map<GameViewModel>(game);
    }
}