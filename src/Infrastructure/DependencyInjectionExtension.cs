using Application.Common.Interfaces.Repository;
using Application.Common.Interfaces.Service;
using Infrastructure.Repository;
using Infrastructure.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IGenreRepository, GenreRepository>();
        services.AddScoped<IGameRepository, GameRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();
        services.AddScoped<IGenreService, GenreService>();
        services.AddScoped<IGameService, GameService>();
        services.AddScoped<IReviewService, ReviewService>();
    }
}