using Cinema.Domain.Models.DTOs;
using FluentValidation;

namespace Cinema.UI.Validators;

public class UpdateHallRequestValidator : AbstractValidator<UpdateHallRequest>
{
    public UpdateHallRequestValidator()
    {
        RuleFor(x => x.HallNumber)
            .GreaterThan(0)
                .WithMessage("Hall number must be greater than 0.");
    }
}
