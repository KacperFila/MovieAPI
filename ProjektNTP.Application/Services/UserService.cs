using AutoMapper;
using ProjektNTP.Application.User.Dtos;
using ProjektNTP.Domain.Abstractions;
using ProjektNTP.Entities;

namespace ProjektNTP.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
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

    public async Task<List<GetUserDto>> GetAllUsers()
    {
        var result = await _userRepository.GetAllUsers();
        var resultDto = _mapper.Map<List<Entities.User>,List<GetUserDto>>(result);
        return resultDto;
    }
}