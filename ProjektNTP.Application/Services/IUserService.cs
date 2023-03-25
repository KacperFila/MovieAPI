using ProjektNTP.Application.User.Dtos;
using ProjektNTP.Entities;

namespace ProjektNTP.Application.Services;

public interface IUserService
{
    public Task<Guid> Create(CreateUserDto user);
}