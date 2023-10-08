using Cinema.Domain.Models.DTOs;
using FluentValidation;

namespace Cinema.UI.Validators;

public class UpdateSeatWithHallIdRequestValidator : AbstractValidator<UpdateSeatWithHallIdRequest>
{
    public UpdateSeatWithHallIdRequestValidator()
    {
        RuleFor(x => x.SeatNumber)
            .NotNull()
                .WithMessage("SeatNumber couldn't be null!")
            .NotEmpty()
                .WithMessage("SeatNumber couldn't be empty!")
            .GreaterThan(0)
                .WithMessage("SeatNumber should be greater than 0!");

        RuleFor(x => x.Row)
            .NotNull()
                .WithMessage("Row couldn't be null!")
            .NotEmpty()
                .WithMessage("Row couldn't be empty!")
            .GreaterThan(0)
                .WithMessage("Row should be greater than 0!");

        RuleFor(x => x.SeatTypeId)
            .NotNull()
                .WithMessage("SeatTypeId couldn't be null!")
            .NotEmpty()
                .WithMessage("SeatTypeId couldn't be empty!")
            .GreaterThan(0)
                .WithMessage("SeatTypeId should be greater than 0!")
            .LessThan(5)
                .WithMessage("SeatTypeId should be smaller than 5!");

        RuleFor(x => x.HallId)
            .NotNull()
                .WithMessage("HallId couldn't be null!")
            .NotEmpty()
                .WithMessage("HallId couldn't be empty!")
            .GreaterThan(0)
                .WithMessage("HallId should be greater than 0!");
    }
}
