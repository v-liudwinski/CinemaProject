using Cinema.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Persistence.Configuration;

public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
{
    public void Configure(EntityTypeBuilder<Purchase> builder)
    {
        builder
            .HasMany(x => x.Tickets)
            .WithOne(x => x.Purchase)
            .HasForeignKey(x => x.PurchaseId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Property(x => x.Price)
                .HasPrecision(9, 2);
    }
}
