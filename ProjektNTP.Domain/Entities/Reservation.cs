using ProjektNTP.Entities;

namespace ProjektNTP.Domain.Entities;

public class Reservation
{
    public Guid Id { get; set; }
    public User User { get; set; } = default!;
    public Guid UserId { get; set; }
    public Showing Showing { get; set; } = default!;
    public Guid ShowingId { get; set; }
    public DateTime ReservationCreatedAt { get; set; } = DateTime.Now;
}