using ProjektNTP.Domain.Entities;

namespace ProjektNTP.Domain.Abstractions;

public interface IMovieRepository
{
    public Task<Guid> CreateMovie(Movie movie);
    public Task<List<Movie>?> GetAllMovies();
    public Task<Movie?> GetMovieById(Guid id);
    public Task<bool> UpdateMovie(Guid id, Movie movie);
    public Task<bool> DeleteMovie(Guid id);
}