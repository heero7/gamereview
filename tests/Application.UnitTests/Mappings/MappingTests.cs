using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Application.Common.Mapping;
using Application.Games.Commands;
using Application.Games.Queries;
using Application.Genres.Commands;
using AutoMapper;
using Domain.Entities;
using Xunit;

namespace Application.UnitTests.Mappings;

public class MappingTests
{
    private readonly IMapper _mapper;
    public MappingTests()
    {
        var configurationProvider = new MapperConfiguration(config 
            => config.AddProfile<GameReviewAutoMapperConfiguration>());
        _mapper = configurationProvider.CreateMapper();
    }
    
    [Theory]
    [InlineData(typeof(CreateGenreCommand), typeof(Genre))]
    [InlineData(typeof(CreateGameCommand), typeof(Game))]
    [InlineData(typeof(Game), typeof(GameViewModel))]
    public void GameReview_Mappings_Should_Map(Type source, Type destination)
    {
        var instanceOfSource = GetInstanceOf(source);
        _mapper.Map(instanceOfSource, source, destination);
    }

    private object GetInstanceOf(Type type)
    {
        if (type.GetConstructor(Type.EmptyTypes) != null)
            return Activator.CreateInstance(type)!;

        // Type without parameterless constructor
        return FormatterServices.GetUninitializedObject(type);
    }
}