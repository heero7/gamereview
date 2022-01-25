using Domain.Common;

namespace Domain.Entities;

public class Game : Entity
{
    public string Name { get; set; } = string.Empty;
    public int GenreId { get; set; }
    public DateOnly ReleasedDate { get; set; }

    // EF Relation
    public Genre Genre { get; set; } 
}