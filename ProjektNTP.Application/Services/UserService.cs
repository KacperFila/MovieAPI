using AutoMapper;
using ProjektNTP.Application.User.Dtos;
using ProjektNTP.Domain.Abstractions;
using ProjektNTP.Entities;

namespace ProjektNTP.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Guid> Create(CreateUserDto user)
    {
        var userToAdd = new Entities.User()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            RoleId = user.RoleId
        };
        var result = await _userRepository.Create(userToAdd);
        return result;
    }
}