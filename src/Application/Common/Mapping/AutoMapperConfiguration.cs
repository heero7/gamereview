using Application.Games.Commands;
using Application.Games.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mapping;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<CreateGameCommand, Game>().ReverseMap();
        CreateMap<Game, GameViewModel>();
        CreateMap<IEnumerable<Game>, GamesByCategoryViewModel>()
            .ForMember(src => src.GamesByCategory, 
                m => m.MapFrom(dest => dest));
    }
}