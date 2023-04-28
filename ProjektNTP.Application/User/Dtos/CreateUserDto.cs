namespace ProjektNTP.Application.User.Dtos;

public class CreateUserDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string confirmPassword { get; set; } = default!;
    public int RoleId { get; set; } = 2;
}