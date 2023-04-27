using FluentValidation;
using ProjektNTP.Application.User.Dtos;
using ProjektNTP.Domain;

namespace ProjektNTP.Application.User.Validators;

public class UpdateUserValidator : AbstractValidator<UpdateUserDto>
{
    private readonly AppDbContext _context;
    public UpdateUserValidator(AppDbContext dbcontext)
    {
        _context = dbcontext;
        RuleFor(u => u.FirstName).Length(1, 20).WithMessage("First Name must be between 1 and 20!");
        RuleFor(u => u.LastName).Length(1, 20).WithMessage("Last Name must be between 1 and 20!");
        RuleFor(u => u.RoleId).NotEmpty();
        RuleFor(u => u.Password).NotEmpty().MinimumLength(8)
            .WithMessage("Password must contain at least 8 characters.");
        RuleFor(u => u.confirmPassword).Equal(u => u.Password).WithMessage("Confirmed password is not identical.");

    }
}