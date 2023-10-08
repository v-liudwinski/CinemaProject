using Cinema.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Persistence.Configuration;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Name)
            .HasMaxLength(50);

        builder
            .HasData
            (
                new Genre { Id = 1, Name = "Action" },
                new Genre { Id = 2, Name = "Adventure" },
                new Genre { Id = 3, Name = "Comedy" },
                new Genre { Id = 4, Name = "Drama" },
                new Genre { Id = 5, Name = "Horror" },
                new Genre { Id = 6, Name = "Romance" },
                new Genre { Id = 7, Name = "Science fiction" },
                new Genre { Id = 8, Name = "Fantasy" },
                new Genre { Id = 9, Name = "Historical" },
                new Genre { Id = 10, Name = "Crime" },
                new Genre { Id = 11, Name = "Thriller" },
                new Genre { Id = 12, Name = "Western" },
                new Genre { Id = 13, Name = "Animation" }
            );
    }
}
