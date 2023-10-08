using Cinema.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Persistence.Configuration;

public class HallConfiguration : IEntityTypeConfiguration<Hall>
{
    public void Configure(EntityTypeBuilder<Hall> builder)
    { 
        builder
            .HasKey(x => x.Id);

        builder
            .HasData
            (
                new Hall { Id = 1, CinemaId = 1, HallNumber = 1 }
            );
    }
}
