using Cinema.Domain.Models.DTOs;
using FluentValidation;

namespace Cinema.UI.Validators;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotNull()
                .WithMessage("Email could not be null!")
            .NotEmpty()
                .WithMessage("Email could not be empty!")
            .EmailAddress()
                .WithMessage("Email is invalid!")
            .MaximumLength(50)
                .WithMessage("50 character limit exceeded!");

        RuleFor(x => x.Password)
            .NotNull()
                .WithMessage("Password could not be null!")
            .NotEmpty()
                .WithMessage("Password could not be empty!")
            .MaximumLength(50)
                .WithMessage("50 character limit exceeded!");
    }
}