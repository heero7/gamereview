using Domain.Common;

namespace Domain.Entities;

public class Review : Entity
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int Rating { get; set; }
    public string ReviewDescription { get; set; } = string.Empty;
    public DateTimeOffset PostedDate { get; set; }
    public int GameId { get; set; }
    
    // EF Relation
    public Game Game { get; set; }
}