using System.Security.Claims;
using ProjektNTP.Application.Movie.Dtos;

namespace ProjektNTP.Application.Services;

public interface IMovieService
{
    public Task<Guid> CreateMovie(CreateMovieDto movie, Guid id);
    public Task<List<GetMovieDto>?> GetAllMovies();
    public Task<GetMovieDto?> GetMovieById(Guid id);
    public Task<bool> UpdateMovieById(Guid movieId, CreateMovieDto movieDto);
    public Task<bool> DeleteMovie(Guid id);
}