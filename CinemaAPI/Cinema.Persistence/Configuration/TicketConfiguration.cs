using Cinema.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Persistence.Configuration;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder
            .HasOne(t => t.Seat)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasIndex(x => x.SeatId)
            .IsUnique(false);

        builder
            .Property(x => x.Price)
            .HasPrecision(7, 2);
    }
}
