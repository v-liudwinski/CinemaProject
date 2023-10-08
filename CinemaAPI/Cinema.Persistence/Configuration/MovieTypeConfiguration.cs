using Cinema.Domain.Models.Entities;
using Cinema.Domain.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Persistence.Configuration;

public class MovieTypeConfiguration : IEntityTypeConfiguration<MovieType>
{
    public void Configure(EntityTypeBuilder<MovieType> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .HasData
            (
                new MovieType { MediaType = MovieTypeEnum._2D, Id = 1 },
                new MovieType { MediaType = MovieTypeEnum._3D, Id = 2 },
                new MovieType { MediaType = MovieTypeEnum.iMax, Id = 3 }
            );
    }
}
