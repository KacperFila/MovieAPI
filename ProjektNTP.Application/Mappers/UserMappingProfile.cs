using AutoMapper;
using ProjektNTP.Application.User.Dtos;
using ProjektNTP.Entities;

namespace ProjektNTP.Application.Mappers;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<CreateUserDto, Entities.User>();
        CreateMap<Entities.User, GetUserDto>()
            .ForMember(u => u.RoleName, opt => opt.MapFrom(user => user.Role.Name))
            .ForMember(u => u.Email, opt => opt.MapFrom(user => user.UserContactDetails.Email))
            .ForMember(u => u.PhoneNumber, opt => opt.MapFrom(user => user.UserContactDetails.PhoneNumber));
    }
}
