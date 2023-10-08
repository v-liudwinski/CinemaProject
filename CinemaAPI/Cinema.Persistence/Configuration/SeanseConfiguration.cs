using Cinema.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Cinema.Persistence.Configuration;

public class SeanseConfiguration : IEntityTypeConfiguration<Seanse>
{
    public void Configure(EntityTypeBuilder<Seanse> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.StartTime);

        builder
            .HasData
            (
                new Seanse { Id = 1, HallId = 1, MovieId = 1, PriceId = 1 , StartTime = DateTime.Parse("2023-04-12") },
                new Seanse { Id = 2, HallId = 1, MovieId = 2, PriceId = 2 , StartTime = DateTime.Parse("2023-05-14") }
            );
    }
}
