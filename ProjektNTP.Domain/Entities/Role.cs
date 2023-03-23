using ProjektNTP.Domain.Entities;

namespace ProjektNTP.Entities;

public class Role
{
    public Guid Id { get; set; }
    public string Name { get; set; }  = default!;
    public List<User>? Users { get; set; }  = default!;
}