using Application.Common.Interfaces.Service;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Games.Queries;

public class GamesByCategoryViewModel
{
    public IEnumerable<GameViewModel> GamesByCategory { get; set; }
}
public class GetGamesByCategoryQuery : IRequest<GamesByCategoryViewModel>
{
    public int CategoryId { get; set; }
}

public class GetGamesByCategoryQueryHandler : IRequestHandler<GetGamesByCategoryQuery, GamesByCategoryViewModel>
{
    private IGameService _gameService;
    private IMapper _mapper;
    
    public GetGamesByCategoryQueryHandler(IGameService gameService, IMapper mapper)
    {
        _gameService = gameService;
        _mapper = mapper;
    }
    
    public async Task<GamesByCategoryViewModel> Handle(GetGamesByCategoryQuery request, CancellationToken cancellationToken)
    {
        var gamesByCategory = await _gameService.GetGamesByCategory(request.CategoryId);
        return _mapper.Map<GamesByCategoryViewModel>(gamesByCategory);
    }
}