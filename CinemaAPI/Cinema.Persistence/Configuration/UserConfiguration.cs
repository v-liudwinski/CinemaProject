using Cinema.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Persistence.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasOne(x => x.UserRefreshToken)
            .WithOne(x => x.User)
            .HasForeignKey<UserRefreshToken>(x => x.UserId);

        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Email)
            .HasMaxLength(50);

        builder
            .Property(x => x.Password)
            .HasMaxLength(50);

        builder
            .Property(x => x.FirstName)
            .HasMaxLength(50);

        builder
            .Property(x => x.LastName)
            .HasMaxLength(50);

        builder
            .Property(x => x.Birthday);

        builder
            .Property(x => x.PhoneNumber)
            .HasMaxLength(20);

        builder
            .HasData
            (
                new User
                {
                    Id = 1,
                    RoleId = 1,
                    Email = "admin@gmail.com",
                    Password = "admin123",
                    FirstName = "Admin",
                    LastName = "Admin",
                    Birthday = DateTime.Parse("2000-05-08"),
                    PhoneNumber = "380999999999",
                },
                new User
                {
                    Id = 2,
                    RoleId = 2,
                    Email = "user@gmail.com",
                    Password = "user123",
                    FirstName = "User",
                    LastName = "User",
                    Birthday = DateTime.Parse("2005-01-01"),
                    PhoneNumber = "380111111111",
                },
                new User
                {
                    Id = 3,
                    RoleId = 2,
                    Email = "zxc@gmail.com",
                    Password = "admin123",
                    FirstName = "Admin",
                    LastName = "Admin",
                    Birthday = DateTime.Parse("2000-05-08"),
                    PhoneNumber = "380999999999",
                },
                new User
                {
                    Id = 4,
                    RoleId = 2,
                    Email = "qsd@gmail.com",
                    Password = "user123",
                    FirstName = "User",
                    LastName = "User",
                    Birthday = DateTime.Parse("2005-01-01"),
                    PhoneNumber = "380111111111",
                },
                new User
                {
                    Id = 5,
                    RoleId = 2,
                    Email = "asd@gmail.com",
                    Password = "admin123",
                    FirstName = "Admin",
                    LastName = "Admin",
                    Birthday = DateTime.Parse("2000-05-08"),
                    PhoneNumber = "380999999999",
                },
                new User
                {
                    Id = 6,
                    RoleId = 2,
                    Email = "qwe@gmail.com",
                    Password = "user123",
                    FirstName = "User",
                    LastName = "User",
                    Birthday = DateTime.Parse("2005-01-01"),
                    PhoneNumber = "380111111111",
                }
            );
    }
}