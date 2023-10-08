using Cinema.Domain.Models.DTOs;
using FluentValidation;

namespace Cinema.UI.Validators;

public class AddSeanseRequestValidator : AbstractValidator<AddSeanseRequest>
{
    public AddSeanseRequestValidator()
    {
        RuleFor(x => x.StartTime)
            .NotNull()
                .WithMessage("Start Time couldn't be null!")
            .NotEmpty()
                .WithMessage("Start Time couldn't be empty!");

        RuleFor(x => x.MovieId)
            .NotNull()
                .WithMessage("Movie ID couldn't be null!")
            .NotEmpty()
                .WithMessage("Movie ID couldn't be empty!");

        RuleFor(x => x.HallId)
            .NotNull()
                .WithMessage("Hall Id couldn't be null!")
            .NotEmpty()
                .WithMessage("Hall Id couldn't be empty!");
    }
}
