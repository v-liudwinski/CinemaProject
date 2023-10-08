using Cinema.Domain.Models.DTOs;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Cinema.UI.Validators;

public class AddUserRequestValidator : AbstractValidator<AddUserRequest>
{
    public AddUserRequestValidator()
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

        RuleFor(x => x.FirstName)
            .NotNull()
                .WithMessage("FirstName could not be null!")
            .NotEmpty()
                .WithMessage("FirstName could not be empty!")
            .MaximumLength(50)
                .WithMessage("50 character limit exceeded!");

        RuleFor(x => x.LastName)
            .NotNull()
                .WithMessage("LastName could not be null!")
            .NotEmpty()
                .WithMessage("LastName could not be empty!")
            .MaximumLength(50)
                .WithMessage("50 character limit exceeded!");

        RuleFor(x => x.Birthday)
            .NotNull()
                .WithMessage("LastName could not be null!")
            .NotEmpty()
                .WithMessage("LastName could not be empty!")
            .Must(x => !x.Equals(default(DateTime)))
                .WithMessage("Invalid Date!");

        RuleFor(x => x.PhoneNumber)
            .NotNull()
                .WithMessage("PhoneNumber could not be null!")
            .NotEmpty()
                .WithMessage("PhoneNumber could not be empty!")
            .MaximumLength(50)
                .WithMessage("50 character limit exceeded!")
            .Must(IsValidPhoneNumber)
                .WithMessage("Phone number isn't valid!");
    }
    private bool IsValidPhoneNumber(string phoneNumber)
    {
        return Regex.IsMatch(phoneNumber, "^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$");
    }
}