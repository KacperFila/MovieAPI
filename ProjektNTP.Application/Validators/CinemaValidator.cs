using FluentValidation;
using ProjektNTP.Domain.Entities;

namespace ProjektNTP.Domain.Validators;

public class CinemaValidator : AbstractValidator<Cinema>
{
    public CinemaValidator()
    {
        RuleFor(c => c.Name).Length(1, 20).WithMessage("Cinema's name must be between 1 and 20 characters!");
        RuleFor(c => c.Address).SetValidator(new AddressValidator());
    }
}