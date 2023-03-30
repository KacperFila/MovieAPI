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

    public Task<bool> UpdateMovie(Guid id, Movie movie)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteMovie(Guid id)
    {
        throw new NotImplementedException();
    }
}