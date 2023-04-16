using ProjektNTP.Application.User.Dtos;

namespace ProjektNTP.Application.Services;

public interface IUserService
{
    public Task<Guid?> Register(CreateUserDto user);
    public Task<List<GetUserDto>?> GetAllUsers();
    public Task<GetUserDto?> GetUserById(Guid id);
    public Task<Guid?> UpdateUserById(Guid id, CreateUserDto userDto);
    public Task<bool> DeleteUserById(Guid id);
}