using Cinema.Domain.Models.DTOs;
using FluentValidation;

namespace Cinema.UI.Validators;

public class AddHallWithCinemaIdRequestValidator : AbstractValidator<AddHallWithCinemaIdRequest>
{
    public AddHallWithCinemaIdRequestValidator()
    {
        RuleFor(x => x.HallNumber)
            .GreaterThan(0)
                .WithMessage("Hall number must be greater than 0.");
    }
}
