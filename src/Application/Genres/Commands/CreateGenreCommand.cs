using Application.Common.Interfaces.Service;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Genres.Commands;

public class CreateGenreCommand : IRequest<int>
{
    public string Name { get; set; }
}

public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, int>
{
    private IGenreService _genreService;
    private IMapper _mapper;

    public CreateGenreCommandHandler(IGenreService genreService, IMapper mapper)
    {
        _genreService = genreService;
        _mapper = mapper;
    }
    
    public async Task<int> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = _mapper.Map<Genre>(request);
        var createdGenre = await _genreService.Add(genre);
        return createdGenre.Id;
    }
}