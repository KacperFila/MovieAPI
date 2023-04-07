using AutoMapper;
using ProjektNTP.Application.Showing.Dtos;

namespace ProjektNTP.Application.Mappers;

public class ShowingMappingProfile : Profile
{
    public ShowingMappingProfile()
    {
        CreateMap<Domain.Entities.Showing, GetShowingDto>()
            .ForMember(dto => dto.MovieName, opt => opt.MapFrom(s => s.Movie.Name))
            .ForMember(dto => dto.CinemaName, opt => opt.MapFrom(s => s.Cinema.Name));
        CreateMap<CreateShowingDto, Domain.Entities.Showing>()
            .ForMember(sh => sh.MovieId, opt => opt.MapFrom(dto => dto.MovieId))
            .ForMember(sh => sh.CinemaId, opt => opt.MapFrom(dto => dto.CinemaId));
    }
}