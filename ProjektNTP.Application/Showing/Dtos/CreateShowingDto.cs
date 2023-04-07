namespace ProjektNTP.Application.Showing.Dtos;

public class CreateShowingDto
{
    public Guid MovieId { get; set; }
    public Guid CinemaId { get; set; }
    public DateTime StartTime { get; set; }
}