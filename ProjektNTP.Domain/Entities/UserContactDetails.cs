namespace ProjektNTP.Entities;

public class UserContactDetails
{
    public Guid Id { get; set; }
    public User User { get; set; } = default!;
    public Guid UserId { get; set; }
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
}