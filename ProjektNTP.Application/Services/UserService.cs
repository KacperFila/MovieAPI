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
            RoleId = user.RoleId,
            UserContactDetails = new UserContactDetails()
            {
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            }
        };
        var addedUser = await _userRepository.Create(userToAdd);
        return await Task.FromResult(addedUser);
    }

    public async Task<List<GetUserDto>?> GetAllUsers()
    {
        var users = await _userRepository.GetAllUsers();
        var usersDto = _mapper.Map<List<GetUserDto>>(users);
        return await Task.FromResult(usersDto);
    }

    public async Task<GetUserDto?> GetUserById(Guid id)
    {
        var user = await _userRepository.GetUserById(id);
        var userDto = _mapper.Map<GetUserDto>(user);
        return await Task.FromResult(userDto);
    }


    public async Task<Guid?> UpdateUserById(Guid id, CreateUserDto newUser)
    {
        var newUserDto = _mapper.Map<Entities.User>(newUser);
        var updatedUser = await _userRepository.UpdateUserById(id, newUserDto);
        return await Task.FromResult(updatedUser);
    }
    public async Task<bool> DeleteUserById(Guid id)
    {
        var deletedUser = await _userRepository.DeleteUserById(id);
        return await Task.FromResult(deletedUser);
    }
}