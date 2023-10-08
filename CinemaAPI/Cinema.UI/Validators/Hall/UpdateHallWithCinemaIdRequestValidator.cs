using Cinema.Domain.Models.DTOs;
using FluentValidation;

namespace Cinema.UI.Validators;

public class UpdateHallWithCinemaIdRequestValidator : AbstractValidator<UpdateHallWithCinemaIdRequest>
{
    public UpdateHallWithCinemaIdRequestValidator()
    {
        RuleFor(x => x.HallNumber)
            .GreaterThan(0)
                .WithMessage("Hall number must be greater than 0.");
    }
}
