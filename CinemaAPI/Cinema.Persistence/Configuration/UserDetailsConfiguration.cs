using Cinema.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Persistence.Configuration;

public class UserDetailsConfiguration : IEntityTypeConfiguration<UserDetails>
{
    public void Configure(EntityTypeBuilder<UserDetails> builder)
    {
        builder
            .HasMany(x => x.Purchase)
            .WithOne(x => x.UserDetails)
            .HasForeignKey(x => x.UserDetailsId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Property(x => x.AvatarUrl)
            .HasMaxLength(250);

        builder
            .HasData
            (
                new UserDetails { Id = 1, AvatarUrl = "", UserId = 1 },
                new UserDetails { Id = 2, AvatarUrl = "", UserId = 2 },
                new UserDetails { Id = 3, AvatarUrl = "", UserId = 3 },
                new UserDetails { Id = 4, AvatarUrl = "", UserId = 4 },
                new UserDetails { Id = 5, AvatarUrl = "", UserId = 5 },
                new UserDetails { Id = 6, AvatarUrl = "", UserId = 6 }
            );
    }
}
