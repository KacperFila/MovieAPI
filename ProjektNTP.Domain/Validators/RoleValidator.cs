using FluentValidation;
using ProjektNTP.Entities;

namespace ProjektNTP.Domain.Validators;

public class RoleValidator : AbstractValidator<Role>
{
    public RoleValidator()
    {
        RuleFor(r => r.Name).Length(1, 10).WithMessage("Role's name must be between 1 and 10 characters!");
    }
}