using Cinema.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Persistence.Configuration;

public class FavouriteConfiguration : IEntityTypeConfiguration<Favourite>
{
    public void Configure(EntityTypeBuilder<Favourite> builder)
    {
        builder
            .HasKey(f => new 
            {
                f.MovieId,
                f.UserDetailsId 
            });

        builder
            .HasOne(f => f.Movie)
            .WithMany(m => m.Favourites)
            .HasForeignKey(f => f.MovieId);

        builder
            .HasOne(f => f.UserDetails)
            .WithMany(ud => ud.Favourites)
            .HasForeignKey(f => f.UserDetailsId);
    }
}
    