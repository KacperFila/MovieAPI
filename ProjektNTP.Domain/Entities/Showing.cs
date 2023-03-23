using ProjektNTP.Entities;

namespace ProjektNTP.Domain.Entities;

public class Showing
{
    public Guid Id { get; set; }
    public Movie Movie { get; set; } = default!;
    public Guid MovieId { get; set; }
    public Cinema Cinema { get; set; } = default!;
    public Guid CinemaId { get; set; }
    public DateTime StartTime { get; set; }
    public List<Reservation>? Reservations { get; set; }
}