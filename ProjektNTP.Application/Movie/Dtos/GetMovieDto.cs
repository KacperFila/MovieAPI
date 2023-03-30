namespace ProjektNTP.Application.Movie.Dtos;

public class GetMovieDto
{
    public string Name { get; set; } = default!;
    public DateTime ReleasedDate { get; set; } = default!;
    public int Duration { get; set; } = default!;
}