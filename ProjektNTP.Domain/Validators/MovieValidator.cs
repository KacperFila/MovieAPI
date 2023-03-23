using FluentValidation;
using ProjektNTP.Domain.Entities;

namespace ProjektNTP.Domain.Validators;

public class MovieValidator : AbstractValidator<Movie>
{
    public MovieValidator()
    {
        RuleFor(m => m.Name).Length(1, 20).WithMessage("Movie's name must be between 1 and 20!");
        RuleFor(m => m.Duration).GreaterThan(0).WithMessage("Duration cannot be shorter than 1 minute!");
        RuleFor(m => m.ReleasedDate).NotEmpty().WithMessage("Released Date cannot be empty!");
    }
}