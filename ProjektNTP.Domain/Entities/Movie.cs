namespace ProjektNTP.Domain.Entities;

public class Movie
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public DateTime ReleasedDate { get; set; } = default!;
    public int Duration { get; set; } = default!;
    public List<Showing>? Showings { get; set; }
    public Guid AddedById { get; set; }
}