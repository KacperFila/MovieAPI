namespace ProjektNTP.Entities;

public class PhoneNumber
{
    public Guid Id { get; set; }
    public User User { get; set; }
    public Guid UserId { get; set; }
    public string Directional { get; set; } = null!;
    public string Number { get; set; } = null!;
}