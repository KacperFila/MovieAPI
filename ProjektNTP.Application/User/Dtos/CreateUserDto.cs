using ProjektNTP.Entities;

namespace ProjektNTP.Application.User.Dtos;

public class CreateUserDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public UserContactDetails UserContactDetails { get; set;  } = default!;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public Guid RoleId { get; set; }
}