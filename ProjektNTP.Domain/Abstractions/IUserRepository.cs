using ProjektNTP.Entities;

namespace ProjektNTP.Domain.Abstractions;

public interface IUserRepository
{
    public Task<Guid> Create(User user);
    public Task<List<User>> GetAllUsers();

}