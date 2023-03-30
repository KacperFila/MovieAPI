using AutoMapper;
using ProjektNTP.Application.Movie.Dtos;

namespace ProjektNTP.Application.Mappers;

public class MovieMappingProfile : Profile
{
    public MovieMappingProfile()
    {
        CreateMap<Domain.Entities.Movie, GetMovieDto>();
        CreateMap<CreateMovieDto, Domain.Entities.Movie>();
    }
}