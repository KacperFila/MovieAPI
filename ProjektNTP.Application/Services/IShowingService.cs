using ProjektNTP.Application.Showing.Dtos;

namespace ProjektNTP.Application.Services;

public interface IShowingService
{
    public Task<Guid> CreateShowing(CreateShowingDto showing);
    public Task<List<GetShowingDto>> GetAllShowings();
    public Task<GetShowingDto> GetShowingById(Guid id);
    public Task<bool> UpdateShowingById(Guid id, CreateShowingDto showing);
    public Task<bool> DeleteShowingById(Guid id);
}