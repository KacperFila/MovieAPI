﻿using FluentValidation;
using ProjektNTP.Domain.Validators;

namespace ProjektNTP.Application.User.Validators;

public class UserValidator : AbstractValidator<Entities.User>
{
    public UserValidator()
    {
        RuleFor(u => u.FirstName).Length(1, 20).WithMessage("First Name must be between 1 and 20!");
        RuleFor(u => u.LastName).Length(1, 20).WithMessage("Last Name must be between 1 and 20!");
        RuleFor(u => u.UserContactDetails).SetValidator(new UserContactDetailsValidator());
        RuleFor(u => u.RoleId).NotEmpty();
    }
}