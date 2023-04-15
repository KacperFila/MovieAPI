using AutoMapper;
using ProjektNTP.Application.Movie.Dtos;
using ProjektNTP.Domain.Abstractions;

namespace ProjektNTP.Application.Services;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _repository;
    private readonly IMapper _mapper;
    
    public MovieService(IMovieRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<Guid> CreateMovie(CreateMovieDto movie)
    {
        var movieFromDto = _mapper.Map<Domain.Entities.Movie>(movie);
        var movieToAdd = await _repository.CreateMovie(movieFromDto);
        return await Task.FromResult(movieToAdd);
    }

    public async Task<List<GetMovieDto>?> GetAllMovies()
    {
        var moviesDtos = _mapper.Map<List<GetMovieDto>>(await _repository.GetAllMovies());
        return await Task.FromResult(moviesDtos);
    }

    public async Task<GetMovieDto?> GetMovieById(Guid id)
    {
        var movieDto = _mapper.Map<GetMovieDto>(await _repository.GetMovieById(id));
        return await Task.FromResult(movieDto);
    }

    public async Task<Guid?> UpdateMovieById(Guid id, CreateMovieDto newMovie)
    {
        var newMovieDto = _mapper.Map<Domain.Entities.Movie>(newMovie);
        var updatedMovie = await _repository.UpdateMovieById(id, newMovieDto);
        return await Task.FromResult(updatedMovie);
    }

    public async Task<bool> DeleteMovie(Guid id)
    {
        var isUserDeleted = await _repository.DeleteMovie(id);
        return await Task.FromResult(isUserDeleted);
    }
}