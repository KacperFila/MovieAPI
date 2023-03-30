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

    public async Task<bool> UpdateMovie(Guid id, CreateMovieDto movie)
    {
        var userToUpdate = _mapper.Map<Domain.Entities.Movie>(movie);
        var updatedUser = await _repository.UpdateMovie(id, userToUpdate);
        return await Task.FromResult(updatedUser);
    }

    public Task<bool> DeleteMovie(Guid id)
    {
        throw new NotImplementedException();
    }
}