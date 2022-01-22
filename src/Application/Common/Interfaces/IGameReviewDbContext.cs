using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IGameReviewDbContext
{
    DbSet<Game> Games { get; }
    DbSet<Review> Reviews { get; }
    DbSet<Genre> Genres { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}