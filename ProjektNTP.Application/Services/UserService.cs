using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ProjektNTP.Application.User.Dtos;
using ProjektNTP.Domain.Abstractions;

namespace ProjektNTP.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher<Domain.Entities.User> _passwordHasher;
    

    public UserService(IUserRepository userRepository, IMapper mapper, IPasswordHasher<Domain.Entities.User> passwordHasher)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }

    public async Task<Guid?> Register(CreateUserDto newUserDto)
    {
        var userToAdd = new Domain.Entities.User()
        {
            Id = newUserDto.Id,
            FirstName = newUserDto.FirstName,
            LastName = newUserDto.LastName,
            RoleId = newUserDto.RoleId,
            Email = newUserDto.Email
        };
        var hashedPassword = _passwordHasher.HashPassword(userToAdd, newUserDto.Password);
        userToAdd.PasswordHash = hashedPassword;
        var result = await _userRepository.Register(userToAdd);
        return result is not null ? await Task.FromResult(result) : await Task.FromResult<Guid?>(null);
    }

    public async Task<List<GetUserDto>?> GetAllUsers()
    {
        var result = await _userRepository.GetAllUsers();

        var resultDto = _mapper.Map<List<GetUserDto>>(result);
        return resultDto;
    }

    public async Task<GetUserDto?> GetUserById(Guid id)
    {
        var result = await _userRepository.GetUserById(id);
        var resultDto = _mapper.Map<GetUserDto>(result);
        return resultDto;
    }


    public async Task<Guid?> UpdateUserById(Guid id, CreateUserDto userDto)
    {
        var mappedUser = _mapper.Map<Domain.Entities.User>(userDto);
        var updatedUser = await _userRepository.UpdateUserById(id, mappedUser);
        return updatedUser is not null ? await Task.FromResult(updatedUser) : await Task.FromResult<Guid?>(null);
    }
    public async Task<bool> DeleteUserById(Guid id)
    {
        var deletedUser = await _userRepository.DeleteUserById(id);
        return await Task.FromResult(deletedUser);
    }
}