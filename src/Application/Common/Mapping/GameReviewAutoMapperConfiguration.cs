using Application.Games.Commands;
using Application.Games.Queries;
using Application.Genres.Commands;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mapping;

public class GameReviewAutoMapperConfiguration : Profile
{
    public GameReviewAutoMapperConfiguration()
    {
        CreateMap<CreateGameCommand, Game>();
        CreateMap<CreateGenreCommand, Genre>();
        CreateMap<Game, GameViewModel>();
        CreateMap<IEnumerable<Game>, GamesByCategoryViewModel>()
            .ForMember(src => src.GamesByCategory, 
                m => m.MapFrom(dest => dest));
    }
}