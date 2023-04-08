using ProjektNTP.Domain.Entities;
using ProjektNTP.Entities;

namespace ProjektNTP.Application.User.Dtos;

public class GetUserDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string RoleName { get; set; } = default!;
}