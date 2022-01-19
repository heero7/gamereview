namespace Domain.Entities;

public class Review
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int Rating { get; set; }
    public string ReviewDescription { get; set; } = string.Empty;
    public DateTimeOffset PostedDate { get; set; }
    
    // EF Relation: Should we use the GameId or the whole Game object?
        //public Guid GameUid { get; set; }
        //public Game Game { get; set; }
}