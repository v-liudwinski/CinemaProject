using Cinema.Domain.Models.Entities;

namespace Cinema.Persistence.Interfaces;

public interface IUserDetailsRepository
{
    Task<UserDetails?> GetUserDetailsAsync(int id);
}
