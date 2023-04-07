using Microsoft.EntityFrameworkCore;
using ProjektNTP.Domain.Abstractions;
using ProjektNTP.Domain.Entities;

namespace ProjektNTP.Infrastructure.Repositories;

public class ShowingRepository : IShowingRepository
{
    private readonly AppDbContext _context;

    public ShowingRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> CreateShowing(Showing showing)
    {
        await _context.AddAsync(showing);
        await _context.SaveChangesAsync();
        return await Task.FromResult(showing.Id);
    }

    public async Task<Showing?> GetShowingById(Guid id)
    {
        var showing = await _context.Showings
            .Include(s => s.Movie)
            .Include(s => s.Cinema)
            .FirstOrDefaultAsync(s => s.Id == id);
        return await Task.FromResult(showing);
    }

    public async Task<List<Showing>?> GetAllShowings()
    {
        var showings = await _context.Showings
            .Include(s => s.Movie)
            .Include(s => s.Cinema)
            .ToListAsync();
        return await Task.FromResult(showings);
    }

    public async Task<bool> UpdateShowingById(Guid id, Showing showing)
    {
        var showingToUpdate = _context.Showings.Any(s => s.Id == id);
        if (!showingToUpdate) return await Task.FromResult(false);
        var abc = await _context.Showings.FirstOrDefaultAsync(s => s.Id == id);
        abc.MovieId = showing.MovieId;
        abc.CinemaId = showing.CinemaId;
        abc.StartTime = showing.StartTime;

        await _context.SaveChangesAsync();
        return await Task.FromResult(true);
    }

    public Task<bool> DeleteShowing(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CinemaExistsAsync(Guid id)
    {
        var cinema = await _context.Cinemas.AnyAsync(c => c.Id == id);
        return await Task.FromResult(cinema);
    }
    public async Task<bool> MovieExistsAsync(Guid id)
    {
        var movie = await _context.Movies.AnyAsync(c => c.Id == id);
        return await Task.FromResult(movie);
    }
}