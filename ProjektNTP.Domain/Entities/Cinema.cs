namespace ProjektNTP.Domain.Entities;

public class Cinema
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public Address Address { get; set; } = default!;
    public List<Showing>? Showings { get; set; }
}