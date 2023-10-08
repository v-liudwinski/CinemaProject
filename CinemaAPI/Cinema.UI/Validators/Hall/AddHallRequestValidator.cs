using Cinema.Domain.Models.DTOs;
using FluentValidation;

namespace Cinema.UI.Validators;

public class AddHallRequestValidator : AbstractValidator<AddHallRequest>
{
    public AddHallRequestValidator()
    {
        RuleFor(x => x.HallNumber)
            .GreaterThan(0)
                .WithMessage("Hall number must be greater than 0.");

        RuleFor(x => x.Seats)
            .NotEmpty()
                .WithMessage("The hall must have at least 1 seat.")
            .NotNull()
                .WithMessage("Hall couldn't be empty!");
    }
}
