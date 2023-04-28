using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using ProjektNTP.Application.Authorization.Policies;
using ProjektNTP.Application.Movie.Dtos;
using ProjektNTP.Domain.Abstractions;

namespace ProjektNTP.Application.Services;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _repository;
    private readonly IMapper _mapper;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserContextService _userContextService;
    public MovieService(IMovieRepository repository, IMapper mapper, IAuthorizationService authorizationService, IUserContextService userContextService)
    {
        _repository = repository;
        _mapper = mapper;
        _authorizationService = authorizationService;
        _userContextService = userContextService;
    }

    public async Task<Guid> CreateMovie(CreateMovieDto movie, Guid id)
    {
        var movieFromDto = _mapper.Map<Domain.Entities.Movie>(movie);
        movieFromDto.AddedById = id;
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

    public async Task<bool> UpdateMovieById(Guid movieId, CreateMovieDto movieDto)
    {
        var newMovie = _mapper.Map<Domain.Entities.Movie>(movieDto);
        var oldMovie = await _repository.GetMovieById(movieId);
        var updatedMovie = await _repository.UpdateMovieById(movieId, newMovie);
        return await Task.FromResult(updatedMovie);
    }

    public async Task<bool> DeleteMovie(Guid id)
    {
        var user = _userContextService.User;
        var userRole = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
        var movie = await _repository.GetMovieById(id);
        if (movie is null) return await Task.FromResult(false);

        var authorizationResult = _authorizationService.AuthorizeAsync(user, movie, new IsOwnerOrAdminRequirement(IsOwnerOrAdminResourceOperation.Delete)).Result;
        if (!authorizationResult.Succeeded) throw new UnauthorizedAccessException();
        
        await _repository.DeleteMovie(id);
        return await Task.FromResult(true);
    }
}