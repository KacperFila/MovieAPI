using Microsoft.EntityFrameworkCore;
using ProjektNTP.Domain.Abstractions;
using ProjektNTP.Domain.Entities;

namespace ProjektNTP.Infrastructure.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly AppDbContext _context;

    public MovieRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> CreateMovie(Movie movie)
    {
        await _context.Movies.AddAsync(movie);
        await _context.SaveChangesAsync();
        return await Task.FromResult(movie.Id);
    }

    public async Task<List<Movie>?> GetAllMovies()
    {
        var movies = await _context.Movies.ToListAsync();
        return await Task.FromResult(movies);
    }

    public async Task<Movie?> GetMovieById(Guid id)
    {
        var movie = await _context.Movies.FirstOrDefaultAsync(u => u.Id == id);
        return await Task.FromResult(movie);
    }

    public async Task<bool> UpdateMovieById(Guid id, Movie movie)
    {
        var updatedMovie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);
        if (updatedMovie is null) return await Task.FromResult(false);

        updatedMovie.Name = movie.Name;
        updatedMovie.ReleasedDate = movie.ReleasedDate;
        updatedMovie.Duration = movie.Duration;

        await _context.SaveChangesAsync();
        return await Task.FromResult(true);
    }

    public async Task<bool> DeleteMovie(Guid id)
    {
        var userToDelete = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);

        if (userToDelete is null) return await Task.FromResult(false);
        _context.Remove(userToDelete);
        await _context.SaveChangesAsync();
        return await Task.FromResult(true);
    }
}