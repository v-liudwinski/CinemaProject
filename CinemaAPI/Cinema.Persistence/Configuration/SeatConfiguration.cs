using Cinema.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Persistence.Configuration;

public class SeatConfiguration : IEntityTypeConfiguration<Seat>
{
    public void Configure(EntityTypeBuilder<Seat> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .HasData
            (
                new Seat { Id = 1, HallId = 1, Row = 1, SeatNumber = 1, SeatTypeId = 2},
                new Seat { Id = 2, HallId = 1, Row = 1, SeatNumber = 2, SeatTypeId = 2},
                new Seat { Id = 3, HallId = 1, Row = 1, SeatNumber = 3, SeatTypeId = 4},
                new Seat { Id = 4, HallId = 1, Row = 1, SeatNumber = 4, SeatTypeId = 4},
                new Seat { Id = 5, HallId = 1, Row = 1, SeatNumber = 5, SeatTypeId = 2},
                new Seat { Id = 6, HallId = 1, Row = 1, SeatNumber = 6, SeatTypeId = 2},
                new Seat { Id = 7, HallId = 1, Row = 2, SeatNumber = 1, SeatTypeId = 1},
                new Seat { Id = 8, HallId = 1, Row = 2, SeatNumber = 2, SeatTypeId = 1},
                new Seat { Id = 9, HallId = 1, Row = 2, SeatNumber = 3, SeatTypeId = 4},
                new Seat { Id = 10, HallId = 1, Row = 2, SeatNumber = 4, SeatTypeId = 4},
                new Seat { Id = 11, HallId = 1, Row = 2, SeatNumber = 5, SeatTypeId = 1},
                new Seat { Id = 12, HallId = 1, Row = 2, SeatNumber = 6, SeatTypeId = 1},
                new Seat { Id = 13, HallId = 1, Row = 3, SeatNumber = 1, SeatTypeId = 3},
                new Seat { Id = 14, HallId = 1, Row = 3, SeatNumber = 2, SeatTypeId = 3},
                new Seat { Id = 15, HallId = 1, Row = 3, SeatNumber = 3, SeatTypeId = 3},
                new Seat { Id = 16, HallId = 1, Row = 3, SeatNumber = 4, SeatTypeId = 3},
                new Seat { Id = 17, HallId = 1, Row = 3, SeatNumber = 5, SeatTypeId = 3},
                new Seat { Id = 18, HallId = 1, Row = 3, SeatNumber = 6, SeatTypeId = 3},
                new Seat { Id = 19, HallId = 1, Row = 3, SeatNumber = 7, SeatTypeId = 3}
            );
    }
}
