using FluentValidation;
using ProjektNTP.Application.User.Dtos;

namespace ProjektNTP.Application.User.Validators;

public class CreateUserValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserValidator()
    {
        RuleFor(u => u.FirstName).Length(1, 20).WithMessage("First Name must be between 1 and 20!");
        RuleFor(u => u.LastName).Length(1, 20).WithMessage("Last Name must be between 1 and 20!");
        RuleFor(u => u.Email).EmailAddress().WithMessage("Email's format is not valid!");
        RuleFor(u => u.PhoneNumber).Matches(@"(?<!\w)(\(?(\+|00)?48\)?)?[ -]?\d{3}[ -]?\d{3}[ -]?\d{3}(?!\w)").WithMessage("Phone's number format is not valid!");
        RuleFor(u => u.RoleId).NotEmpty();
    }
}