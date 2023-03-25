using FluentValidation;
using ProjektNTP.Domain.Entities;

namespace ProjektNTP.Domain.Validators;

public class ShowingValidator : AbstractValidator<Showing>
{
    public ShowingValidator()
    {
        RuleFor(s => s.StartTime).NotEmpty().WithMessage("Start Time cannot be empty!");
    }
}