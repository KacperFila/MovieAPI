namespace ProjektNTP.Application.User.Dtos;

public class UpdateUserDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string confirmPassword { get; set; } = default!;
    public int RoleId { get; set; } = 1;
}