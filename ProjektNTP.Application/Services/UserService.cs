using ProjektNTP.Abstractions;
using ProjektNTP.Entities;

namespace ProjektNTP.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
}