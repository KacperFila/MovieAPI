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
                Email = user.UserContactDetails.Email,
                PhoneNumber = user.UserContactDetails.PhoneNumber
            }
        };
        var result = await _userRepository.Create(userToAdd);
        return result;
    }

    public async Task<List<GetUserDto>> GetAllUsers()
    {
        var result = await _userRepository.GetAllUsers();

        var resultDto = _mapper.Map<List<GetUserDto>>(result);
        return resultDto;
    }

    public async Task<GetUserDto> GetUserById(Guid id)
    {
        var result = await _userRepository.GetUserById(id);
        var resultDto = _mapper.Map<GetUserDto>(result);
        return resultDto;
    }

    public async Task<bool> DeleteUserById(Guid id)
    {
        var deletedUser = await _userRepository.DeleteUserById(id);
        return await Task.FromResult(deletedUser);
    }

    public async Task<bool> UpdateUserById(Guid id, CreateUserDto userDto)
    {
        var mappedUser = _mapper.Map<Entities.User>(userDto);
        var updatedUser = await _userRepository.UpdateUserById(id, mappedUser);
        return updatedUser ? await Task.FromResult(true) : await Task.FromResult(false);
    }
}
