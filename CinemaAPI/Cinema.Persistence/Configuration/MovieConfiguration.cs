using Cinema.Domain.Models.Entities;
using Cinema.Domain.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Persistence.Configuration;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.OriginalTitle)
            .HasMaxLength(100);

        builder
            .Property(x => x.Title)
            .HasMaxLength(100);

        builder
            .Property(x => x.Duration);

        builder
            .Property(x => x.ReleaseDate);

        builder
            .Property(x => x.PosterUrl)
            .HasMaxLength(160);

        builder
            .HasData
            (
                new Movie 
                { 
                    Id = 1, 
                    OriginalTitle = "Shrek", 
                    Title = "Зелений чолов'яга",
                    Duration = 145,
                    ReleaseDate = DateTime.Parse("1999-04-01"),
                    PosterUrl = "https://i.etsystatic.com/27475238/r/il/f9eed6/3758942437/il_fullxfull.3758942437_9564.jpg",
                    MovieTypeId = 1,
                },
                new Movie
                {
                    Id = 2,
                    OriginalTitle = "Titanic",
                    Title = "Затонувший корабель",
                    Duration = 120,
                    ReleaseDate = DateTime.Parse("1995-01-01"),
                    PosterUrl = "https://i.ebayimg.com/images/g/MHIAAOSwsMhiib8p/s-l1600.jpg",
                    MovieTypeId = 2,
                },
                new Movie
                {
                    Id = 3,
                    OriginalTitle = "Borat",
                    Title = "Смішний казах",
                    Duration = 160,
                    ReleaseDate = DateTime.Parse("2006-11-02"),
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BMTk0MTQ3NDQ4Ml5BMl5BanBnXkFtZTcwOTQ3OTQzMw@@._V1_.jpg",
                    MovieTypeId = 3,
                }, 
                new Movie
                {
                    Id = 4,
                    OriginalTitle = "Mask",
                    Title = "Зелений чорт",
                    Duration = 170,
                    ReleaseDate = DateTime.Parse("1999-12-23"),
                    PosterUrl = "https://m.media-amazon.com/images/M/MV5BOWExYjI5MzktNTRhNi00Nzg2LThkZmQtYWVkYjRlYWI2MDQ4XkEyXkFqcGdeQXVyNTAyODkwOQ@@._V1_.jpg",
                    MovieTypeId = 1,
                },
                new Movie
                {
                    Id = 5,
                    OriginalTitle = "Kung Fu Panda",
                    Title = "Чорнобілий ведмідь",
                    Duration = 120,
                    ReleaseDate = DateTime.Parse("1995-01-01"),
                    PosterUrl = "https://static.posters.cz/image/1300/poster/kung-fu-panda-i13408.jpg",
                    MovieTypeId = 2,
                },
                new Movie
                {
                    Id = 6,
                    OriginalTitle = "Avatar",
                    Title = "Сині люди",
                    Duration = 135,
                    ReleaseDate = DateTime.Parse("2009-05-27"),
                    PosterUrl = "https://i.ebayimg.com/images/g/URcAAOSwC31jZQ11/s-l500.jpg",
                    MovieTypeId = 3,
                }
            );
    }
}
