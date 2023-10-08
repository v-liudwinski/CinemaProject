using Cinema.Domain.Models.DTOs;
using FluentValidation;

namespace Cinema.UI.Validators;

public class UpdatePriceRequestValidator : AbstractValidator<UpdatePriceRequest>
{
    public UpdatePriceRequestValidator()
    {
        RuleFor(x => x.Cost)
            .GreaterThan(0)
                .WithMessage("Price must be greater than 0!");

        RuleFor(x => x.Cost)
            .LessThan(100000)
                .WithMessage("Price must be less than 100000!");
    }
}
