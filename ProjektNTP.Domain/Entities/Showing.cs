using ProjektNTP.Entities;

namespace ProjektNTP.Domain.Entities;

public class Showing
{
    public Guid Id { get; set; }
    public Movie Movie { get; set; } = default!;
    public Cinema Cinema { get; set; } = default!;
    public DateTime StartTime { get; set; }
    public List<User>? Viewers { get; set; } 
}