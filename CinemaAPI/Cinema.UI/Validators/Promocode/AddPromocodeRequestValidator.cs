using Cinema.Domain.Models.DTOs;
using FluentValidation;

namespace Cinema.UI.Validators;

public class AddPromocodeRequestValidator : AbstractValidator<AddPromocodeRequest>
{
	public AddPromocodeRequestValidator()
	{
        RuleFor(x => x.Name)
            .NotNull()
                .WithMessage("Name couldn't be null!")
            .NotEmpty()
                .WithMessage("Name couldn't be empty!")
            .MaximumLength(50)
                .WithMessage("50 character limit exceeded!");

        RuleFor(x => x.Percentage)
            .GreaterThan(0)
                .WithMessage("Percentage must be greater than 0.")
            .LessThan(100)
                .WithMessage("Percentage must be less than 100.")
            .NotNull()
                .WithMessage("Percentage couldn't be null!")
            .NotEmpty()
                .WithMessage("Percentage couldn't be empty!");        
    }
}
