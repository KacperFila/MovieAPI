using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using ProjektNTP.Application.Services;
using ProjektNTP.Application.Showing.Dtos;
using ProjektNTP.Application.Validators;
using ProjektNTP.Domain.Abstractions;

namespace ProjektNTP.Application.Showing.Validators;

public class CreateShowingValidator : AbstractValidator<CreateShowingDto>
{
    private readonly IShowingRepository _repository;
    public CreateShowingValidator(IShowingRepository repository)
    {
        _repository = repository;
        RuleFor(s => s.StartTime).NotNull(); //trzeba jakos inaczej
        RuleFor(s => s.CinemaId).MustAsync(CinemaExistsInDatabase)
            .WithMessage("Cinema with given id does not exist in the database!");
        RuleFor(s => s.MovieId).MustAsync(MovieExistsInDatabase)
            .WithMessage("Movie with given id does not exist in the database!");
    }

    private async Task<bool> CinemaExistsInDatabase(Guid cinemaId, CancellationToken token)
    {
        var isCinemaExisting = await _repository.CinemaExistsAsync(cinemaId);
        return await Task.FromResult(isCinemaExisting);
    }
    private async Task<bool> MovieExistsInDatabase(Guid movieId, CancellationToken token)
    {
        var isMovieExisting = await _repository.MovieExistsAsync(movieId);
        return await Task.FromResult(isMovieExisting);
    }
}