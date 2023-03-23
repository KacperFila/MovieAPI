using ProjektNTP.Entities;

namespace ProjektNTP.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public UserContactDetails UserContactDetails { get; set;  } = default!;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public Role Role { get; set; } = default!;
    public Guid RoleId { get; set; }
    public List<Reservation>? Reservations { get; set; }
}