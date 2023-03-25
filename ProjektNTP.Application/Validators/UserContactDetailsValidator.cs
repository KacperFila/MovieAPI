using FluentValidation;
using ProjektNTP.Entities;

namespace ProjektNTP.Domain.Validators;

public class UserContactDetailsValidator : AbstractValidator<UserContactDetails>
{
    public UserContactDetailsValidator()
    {
        RuleFor(u => u.PhoneNumber).Matches(@"(?<!\w)(\(?(\+|00)?48\)?)?[ -]?\d{3}[ -]?\d{3}[ -]?\d{3}(?!\w)").WithMessage("Phone's number format is not valid!");
        RuleFor(u => u.Email).EmailAddress().WithMessage("Email's format is not valid!");
    }
}