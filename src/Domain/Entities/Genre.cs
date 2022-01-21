using Domain.Common;

namespace Domain.Entities;

public class Genre : Entity
{
    public string Name { get; set; }
    
    // EF Relation
    public IEnumerable<Game> Games { get; set; }
}