using Cinema.Domain.Models.DTOs;
using FluentValidation;

namespace Cinema.UI.Validators;

public class AddReviewRequestValidator : AbstractValidator<AddReviewRequest>
{
    public AddReviewRequestValidator()
    {
        RuleFor(x => x.Description)
            .NotNull()
                .WithMessage("Description could not be null!")
            .MaximumLength(250)
                .WithMessage("Description max length 250!");

        RuleFor(x => x.Rate)
            .NotNull()
                .WithMessage("Rate could not be null!")
            .NotEmpty()
                .WithMessage("Rate could not be empty!")
            .GreaterThanOrEqualTo(0)
                .WithMessage("Rate should be greater than or equal 0!")
            .LessThanOrEqualTo(10)
                .WithMessage("Rate should be less than or equal 10!");

        RuleFor(x => x.UserDetailsId)
            .NotNull()
                .WithMessage("UserDetailsId could not be null!")
            .NotEmpty()
                .WithMessage("UserDetailsId could not be empty!")
            .GreaterThan(0)
                .WithMessage("UserDetailsId should be greater than 0!");
        
        RuleFor(x => x.MovieDetailsId)
            .NotNull()
                .WithMessage("MovieDetailsId could not be null!")
            .NotEmpty()
                .WithMessage("MovieDetailsId could not be empty!")
            .GreaterThan(0)
                .WithMessage("MovieDetailsId should be greater than 0!");
    }
}