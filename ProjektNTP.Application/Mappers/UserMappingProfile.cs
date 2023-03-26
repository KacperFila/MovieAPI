using AutoMapper;
using ProjektNTP.Application.User.Dtos;
using ProjektNTP.Entities;

namespace ProjektNTP.Application.Mappers;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<CreateUserDto, Entities.User>();
        CreateMap<GetUserDto, Entities.User>();
        // .ForMember(u => u.UserContactDetails, opt => opt.MapFrom(src => new UserContactDetails
        // {
        //     Email = src.Email,
        //     PhoneNumber = src.PhoneNumber
        // }));
        //.ForPath(u => u.Role.Name, opt => opt.MapFrom(src => src.RoleName));


    }
}
