namespace ProjektNTP.Domain.Entities;

public class Showing
{
    public Guid Id { get; set; }
    public Movie Movie { get; set; } = default!;
    public Guid MovieId { get; set; }
    public Cinema Cinema { get; set; } = default!;
    public Guid CinemaId { get; set; }
    public DateTime StartTime { get; set; } = DateTime.UtcNow;
    public List<Reservation>? Reservations { get; set; }
}