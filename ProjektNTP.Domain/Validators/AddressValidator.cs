using FluentValidation;
using ProjektNTP.Domain.Entities;

namespace ProjektNTP.Domain.Validators;

public class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(a => a.City).Length(1, 20).WithMessage("City must be between 1 and 20!");
        RuleFor(a => a.Street).Length(1, 20).WithMessage("Street must be between 1 and 20!");
        RuleFor(a => a.PostalCode).Length(1, 10).WithMessage("Postal Code must be between 1 and 20!");
        RuleFor(a => a.BuildingNumber).Length(1, 7).WithMessage("Building Number must be between 1 and 7!");
    }
}