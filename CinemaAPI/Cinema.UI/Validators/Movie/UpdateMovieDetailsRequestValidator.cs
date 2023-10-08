using Cinema.Domain.Models.DTOs.Movie;
using FluentValidation;

namespace Cinema.UI.Validators.Movie;

public class UpdateMovieDetailsRequestValidator : AbstractValidator<UpdateMovieDetailsRequest>
{
    public UpdateMovieDetailsRequestValidator()
    {
        RuleFor(x => x.Description)
            .MaximumLength(400)
                .WithMessage("Description shoud have less than 400 characters.")
            .NotNull()
                .WithMessage("Description couldn't be null!")
            .NotEmpty()
                .WithMessage("Description couldn't be empty!");

    RuleFor(x => x.Producers)
            .NotNull()
                .WithMessage("Producer couldn't be null!")
            .NotEmpty()
                .WithMessage("Producer couldn't be empty!")
            .MaximumLength(50)
                .WithMessage("Producer shoud have less than 50 characters.");

    RuleFor(x => x.AgeLimit)
            .NotNull()
                .WithMessage("Age limit couldn't be null!")
            .NotEmpty()
                .WithMessage("Age limit couldn't be empty!");

    RuleFor(x => x.IndependentRate)
            .InclusiveBetween(0, 10)
                .WithMessage("Rating should be between 0 and 10 inclusive!")
            .NotNull()
                .WithMessage("Rating couldn't be null!")
            .NotEmpty()
                .WithMessage("Rating couldn't be empty!");

    RuleFor(x => x.Country)
            .MaximumLength(50)
                .WithMessage("Producer shoud have less than 50 characters.")
            .NotNull()
                .WithMessage("Country limit couldn't be null!")
            .NotEmpty()
                .WithMessage("Country limit couldn't be empty!");

    RuleFor(x => x.MovieTrailerUrl)
            .MaximumLength(50)
                .WithMessage("MovieTrailerUrl shoud have less than 50 characters.")
            .NotNull()
                .WithMessage("MovieTrailerUrl limit couldn't be null!")
            .NotEmpty()
                .WithMessage("MovieTrailerUrl limit couldn't be empty!");

    RuleFor(x => x.StartDate)
            .NotNull()
                .WithMessage("StartDate couldn't be null!")
            .NotEmpty()
                .WithMessage("StartDate couldn't be empty!");

    RuleFor(x => x.EndDate)
            .NotNull()
                .WithMessage("EndDate couldn't be null!")
            .NotEmpty()
                .WithMessage("EndDate couldn't be empty!");
}
}
