using Cinema.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Persistence.Configuration;

public class MovieDetailsConfiguration : IEntityTypeConfiguration<MovieDetails>
{
    public void Configure(EntityTypeBuilder<MovieDetails> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Description)
            .HasMaxLength(400);

        builder
            .Property(x => x.Producers)
            .HasMaxLength(50);

        builder
            .Property(x => x.AgeLimit);

        builder
            .Property(x => x.IndependentRate)
            .HasPrecision(4, 2);

        builder
            .Property(x => x.Country)
            .HasMaxLength(50);

        builder
            .Property(x => x.MovieTrailerUrl)
            .HasMaxLength(50);

        builder
            .Property(x => x.StartDate);

        builder
            .Property(x => x.EndDate);

        builder
            .HasData
            (
                new MovieDetails
                {
                    Id = 1,
                    Description = @"Мирний зелений чолов'яга, намагається релаксувати в своєму болоті, але спочатку йому заважає цирк, а потім новий надокучливий друг віслюк.",
                    Producers = "Mr Producer",
                    AgeLimit = 5,
                    IndependentRate = 9.7,
                    Country = "USA",
                    MovieTrailerUrl = "www.shrekMovieTrailerUrl.com",
                    StartDate = DateTime.Parse("2000-05-03"),
                    EndDate = DateTime.Parse("2010-05-03"),
                    MovieId = 1
                },
                new MovieDetails
                {
                    Id = 2,
                    Description = @"Чувачок потрапив на корабель, корабель затонув чувачку сподобалась дівчина, там ще була та сцена на кораблі, і потім він затонув ніби.",
                    Producers = "Mr Producer",
                    AgeLimit = 16,
                    IndependentRate = 9.1,
                    Country = "USA",
                    MovieTrailerUrl = "www.TitanicMovieTrailerUrl.com",
                    StartDate = DateTime.Parse("1995-06-06"),
                    EndDate = DateTime.Parse("2020-09-09"),
                    MovieId = 2
                },
                new MovieDetails
                {
                    Id = 3,
                    Description = @"Борат стає інтервью'єром і напрвляється в Сполучені Штати щоб зустрітися з Памелою Андерсон, по дорозі розкидуючись смішнулічками.",
                    Producers = "Mr Producer",
                    AgeLimit = 20,
                    IndependentRate = 10,
                    Country = "USA",
                    MovieTrailerUrl = "www.BoratMovieTrailerUrl.com",
                    StartDate = DateTime.Parse("2006-05-03"),
                    EndDate = DateTime.Parse("2020-05-03"),
                    MovieId = 3
                },
                new MovieDetails
                {
                    Id = 4,
                    Description = @"Невдаха Джим Кері знаходить маску на березі моря і вона фіксить всі його проблеми.",
                    Producers = "Mr Producer",
                    AgeLimit = 16,
                    IndependentRate = 7.1,
                    Country = "USA",
                    MovieTrailerUrl = "www.MaskMovieTrailerUrl.com",
                    StartDate = DateTime.Parse("1999-06-06"),
                    EndDate = DateTime.Parse("2015-09-09"),
                    MovieId = 4
                },
                new MovieDetails
                {
                    Id = 5,
                    Description = @"Божевільна стара черепаха, вибирає по приколу ведмідя-офіціанта в якості воїна ящірки, і він стає ним за 2 дня, знецінюючи працю інших.",
                    Producers = "Mr Producer",
                    AgeLimit = 3,
                    IndependentRate = 3,
                    Country = "USA",
                    MovieTrailerUrl = "www.shrekKungFuTrailerUrl.com",
                    StartDate = DateTime.Parse("2003-05-03"),
                    EndDate = DateTime.Parse("2014-05-03"),
                    MovieId = 5
                },
                new MovieDetails
                {
                    Id = 6,
                    Description = @"Якісь сині трьох метрові створіння, шось там роблять, я не знаю бо не дивився.",
                    Producers = "Mr Producer",
                    AgeLimit = 17,
                    IndependentRate = 6.1,
                    Country = "USA",
                    MovieTrailerUrl = "www.AvatarMovieTrailerUrl.com",
                    StartDate = DateTime.Parse("2009-06-06"),
                    EndDate = DateTime.Parse("2020-09-09"),
                    MovieId = 6
                }
            );
    }
}
