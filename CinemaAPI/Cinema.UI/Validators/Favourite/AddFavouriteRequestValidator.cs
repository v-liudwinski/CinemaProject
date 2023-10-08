using Cinema.Domain.Models.DTOs;
using FluentValidation;

namespace Cinema.UI.Validators;

public class AddFavouriteRequestValidator : AbstractValidator<AddFavouriteRequest>
{
    public AddFavouriteRequestValidator()
    {
        RuleFor(x => x.UserDetailsId)
            .NotNull()
                .WithMessage("UserDetailsId could not be null!")
            .NotEmpty()
                .WithMessage("UserDetailsId could not be empty!")
            .GreaterThan(0)
                .WithMessage("UserDetailsId should be greater than 0!");
        
        RuleFor(x => x.MovieId)
            .NotNull()
                .WithMessage("MovieId could not be null!")
            .NotEmpty()
                .WithMessage("MovieId could not be empty!")
            .GreaterThan(0)
                .WithMessage("MovieId should be greater than 0!");
    }
}