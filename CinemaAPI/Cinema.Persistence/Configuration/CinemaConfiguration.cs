using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Persistence.Configuration;

public class CinemaConfiguration : IEntityTypeConfiguration<Domain.Models.Entities.Cinema>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Entities.Cinema> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.PhoneNumber)
            .HasMaxLength(20);

        builder
            .Property(x => x.Name)
            .HasMaxLength(50);

        builder
            .Property(x => x.Email)
            .HasMaxLength(50);

        builder
            .Property(x => x.Address)
            .HasMaxLength(50);

        builder
            .Property(x => x.City)
            .HasMaxLength(50);

        builder
            .HasData
            (
                new Domain.Models.Entities.Cinema
                {
                    Id = 1,
                    Name = "Stupka",
                    Email = "stupka@gmail.com",
                    Address = "Vul. Bogdana Khmelnitskogo",
                    City = "Kiyv",
                    PhoneNumber = "380997813842"
                }
            );
    }
}
