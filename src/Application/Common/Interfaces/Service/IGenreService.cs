using Domain.Entities;

namespace Application.Common.Interfaces.Service;

public interface IGenreService : IDisposable
{
    Task<Genre> Add(Genre genre);
    Task<Genre> GetById(int id);
    Task<Genre> Update(Genre genre);
    Task<bool> Remove(Genre genre);
}