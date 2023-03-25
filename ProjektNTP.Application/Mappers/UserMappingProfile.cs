using AutoMapper;
using ProjektNTP.Application.User.Dtos;

namespace ProjektNTP.Application.Mappers;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<CreateUserDto, Entities.User>();
    }
}