using Domain.Common;

namespace Domain.Entities;

public class Game : Entity
{
    public string Name { get; set; } = string.Empty;
    public int GenreId { get; set; }
    public DateTime ReleaseDate { get; set; } // Think about validation, using a value object.

    // EF Relation
    public Genre Genre { get; set; } 
}