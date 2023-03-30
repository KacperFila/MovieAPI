using ProjektNTP.Application.Movie.Dtos;

namespace ProjektNTP.Application.Services;

public interface IMovieService
{
    public Task<Guid> CreateMovie(CreateMovieDto movie);
    public Task<List<GetMovieDto>?> GetAllMovies();
    public Task<GetMovieDto?> GetMovieById(Guid id);
    public Task<bool> UpdateMovie(Guid id, CreateMovieDto movie);
    public Task<bool> DeleteMovie(Guid id);
}