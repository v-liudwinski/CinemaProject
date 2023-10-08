using Cinema.Domain.Models.Entities;
using Cinema.Domain.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Persistence.Configuration;

public class SeatTypeConfigutation : IEntityTypeConfiguration<SeatType>
{
    public void Configure(EntityTypeBuilder<SeatType> builder)
    {
        builder
            .HasKey(x => x.Id);
        
        builder
            .Property(x => x.Price)
                .HasPrecision(7, 2);

        builder
            .HasData
            (
                new SeatType { Type = SeatTypeEnum.Normal, Id = 1, Price = 10 },
                new SeatType { Type = SeatTypeEnum.ForDisablers, Id = 2, Price = 15 },
                new SeatType { Type = SeatTypeEnum.ForKissing, Id = 3, Price = 25 },
                new SeatType { Type = SeatTypeEnum.VIP, Id = 4, Price = 35 }
            );
    }
}
