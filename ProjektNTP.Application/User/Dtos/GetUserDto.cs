namespace ProjektNTP.Application.User.Dtos;

public class GetUserDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string RoleName { get; set; } = default!;
}