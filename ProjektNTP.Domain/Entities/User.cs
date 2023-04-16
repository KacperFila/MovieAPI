namespace ProjektNTP.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; }  = default!;
    public string PasswordHash { get; set; } = default!;
    public int RoleId { get; set; }
    public virtual Role Role { get; set; } = default!;
    public List<Reservation>? Reservations { get; set; }
}