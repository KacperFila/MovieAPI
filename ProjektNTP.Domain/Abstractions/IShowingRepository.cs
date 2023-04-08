using ProjektNTP.Domain.Entities;

namespace ProjektNTP.Domain.Abstractions;

public interface IShowingRepository
{
    public Task<Guid> CreateShowing(Showing showing);
    public Task<Showing?> GetShowingById(Guid id);
    public Task<List<Showing>?> GetAllShowings();
    public Task<bool> UpdateShowingById(Guid id, Showing showing);
    public Task<bool> DeleteShowingById(Guid id);
    public Task<bool> CinemaExistsAsync(Guid id);
    public Task<bool> MovieExistsAsync(Guid id);
}