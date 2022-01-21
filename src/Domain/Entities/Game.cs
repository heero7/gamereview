using Domain.Common;

namespace Domain.Entities;

public class Game : Entity
{
    public string Name { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; } // Could this be a value type? How do we handle N/A games?
    public int GenreId { get; set; }
    
    // EF Relation
    public Genre Genre { get; set; } 
}