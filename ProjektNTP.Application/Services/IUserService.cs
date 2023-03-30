using ProjektNTP.Application.User.Dtos;
using ProjektNTP.Entities;

namespace ProjektNTP.Application.Services;

public interface IUserService
{
    public Task<Guid> Create(CreateUserDto user);
    public Task<List<GetUserDto>> GetAllUsers();
    public Task<GetUserDto> GetUserById(Guid id);
    public Task<bool> UpdateUserById(Guid id, CreateUserDto userDto);
    public Task<bool> DeleteUserById(Guid id);
}