using ProjektNTP.Entities;

namespace ProjektNTP.Application.User.Dtos;

public class CreateUserDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Email { get; set; } = default!;
    public Guid RoleId { get; set; }
}