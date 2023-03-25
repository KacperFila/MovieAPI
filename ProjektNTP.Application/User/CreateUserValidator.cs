using FluentValidation;
using ProjektNTP.Application.User.Dtos;

namespace ProjektNTP.Domain.Validators;

public class CreateUserValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserValidator()
    {
        RuleFor(u => u.FirstName).Length(1, 20).WithMessage("First Name must be between 1 and 20!");
        RuleFor(u => u.LastName).Length(1, 20).WithMessage("Last Name must be between 1 and 20!");
        RuleFor(u => u.UserContactDetails).NotEmpty().SetValidator(new UserContactDetailsValidator());
        RuleFor(u => u.RoleId).NotEmpty();
    }
}