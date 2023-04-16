namespace ProjektNTP.Domain.Entities;

public class Reservation
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = default!;
    public Showing Showing { get; set; } = default!;
    public Guid ShowingId { get; set; }
    public DateTime ReservationCreatedAt { get; set; } = DateTime.Now;
}