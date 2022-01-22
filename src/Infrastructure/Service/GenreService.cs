using Application.Common.Interfaces.Repository;
using Application.Common.Interfaces.Service;
using Domain.Entities;

namespace Infrastructure.Service;

public class GenreService : IGenreService
{
    private readonly IGenreRepository _genreRepository;

    public GenreService(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }
    
    public void Dispose()
    {
        _genreRepository.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task<Genre> Add(Genre genre)
    {
        // Validate that one doesn't exist already
        await _genreRepository.Add(genre);
        return genre;
    }

    public async Task<Genre> GetById(int id) => await _genreRepository.GetById(id);

    public async Task<Genre> Update(Genre genre)
    {
        // Validate that this exists first before updating.
        await _genreRepository.Update(genre);
        return genre;
    }

    public async Task<bool> Remove(Genre genre)
    {
        // Validate that the genre exists first.
        // Make sure that all genres
        await _genreRepository.Remove(genre);
        return true;
    }
}