using AutoMapper;
using ProjektNTP.Application.User.Dtos;

namespace ProjektNTP.Application.Mappers;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<CreateUserDto, Domain.Entities.User>();
        CreateMap<Domain.Entities.User, GetUserDto>()
            .ForMember(dto => dto.RoleName, opt => opt.MapFrom(u => u.Role.Name));
        CreateMap<UpdateUserDto, Domain.Entities.User>();
    }
}