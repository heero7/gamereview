namespace Domain.Entities;

public class Game : Entity
{
    public Guid Uid { get; set; }
    public string Name { get; set; }
    public int AverageRating { get; set; }
    public DateTime ReleaseDate { get; set; }
}