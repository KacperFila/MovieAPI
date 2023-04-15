using ProjektNTP.Entities;

namespace ProjektNTP.Domain.Abstractions;

public interface IUserRepository
{
    public Task<Guid> Create(User user);
    public Task<List<User>?> GetAllUsers();
    public Task<User?> GetUserById(Guid id);
    public Task<Guid?> UpdateUserById(Guid id, User user);
    public Task<bool> DeleteUserById(Guid id);
}