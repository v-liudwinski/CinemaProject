using Cinema.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Persistence.Configuration;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder
            .HasKey(x => x.Id);


        builder
            .Property(x => x.Description)
            .HasMaxLength(250);

        builder
            .Property(x => x.Rate)
            .HasPrecision(2, 2)
            .HasMaxLength(10);
    }
}