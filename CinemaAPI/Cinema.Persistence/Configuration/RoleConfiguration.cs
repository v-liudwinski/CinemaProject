using Cinema.Domain.Models.Entities;
using Cinema.Domain.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Persistence.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder.HasData
        (
            new Role { RoleName = RoleEnum.Admin, Id = 1 },
            new Role { RoleName = RoleEnum.User, Id = 2 }
        );
    }
}
