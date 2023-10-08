using Cinema.Domain.Models.Enums;

namespace Cinema.Domain.Models.Entities;

public class Role
{
    public int Id { get; set; }
    public RoleEnum RoleName { get; set; }
}