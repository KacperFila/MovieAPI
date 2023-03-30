using FluentValidation;
using ProjektNTP.Application.Movie.Dtos;

namespace ProjektNTP.Application.Movie;

public class CreateMovieValidator : AbstractValidator<CreateMovieDto>
{
    public CreateMovieValidator()
    {
        RuleFor(m => m.Name).Length(1, 20).WithMessage("Movie's name must be between 1 and 20!");
        RuleFor(m => m.Duration).GreaterThan(0).WithMessage("Duration cannot be shorter than 1 minute!");
        RuleFor(m => m.ReleasedDate).NotEmpty().WithMessage("Released Date cannot be empty!");
    }
}