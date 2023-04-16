using ProjektNTP.Domain.Entities;

namespace ProjektNTP.Domain.Abstractions;

public interface IUserRepository
{
    public Task<Guid?> Register(User user);
    public Task<List<User>?> GetAllUsers();
    public Task<User?> GetUserById(Guid id);
    public Task<Guid?> UpdateUserById(Guid id, User user);
    public Task<bool> DeleteUserById(Guid id);
}