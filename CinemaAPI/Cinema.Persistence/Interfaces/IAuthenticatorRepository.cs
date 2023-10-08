using Cinema.Domain.Models.Entities;

namespace Cinema.Persistence.Interfaces;

public interface IAuthenticatorRepository
{
    Task<User?> AuthenticateAsync(string name, string password);
}