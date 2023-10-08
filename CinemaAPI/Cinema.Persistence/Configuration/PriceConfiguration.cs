using Cinema.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Persistence.Configuration;

public class PriceConfiguration : IEntityTypeConfiguration<Price>
{
    public void Configure(EntityTypeBuilder<Price> builder)
    {
        builder
            .Property(x => x.Cost)
                .HasPrecision(7,2);

        builder
            .HasData
            (
                new Price { Id = 1, Cost = 100 },
                new Price { Id = 2, Cost = 200 },
                new Price { Id = 3, Cost = 300 }
            );
    }
}
