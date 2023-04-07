namespace ProjektNTP.Application.Showing.Dtos;

public class GetShowingDto
{
    public string MovieName { get; set; } = default!;
    public string CinemaName { get; set; } = default!;
    public DateTime StartTime { get; set; }
}