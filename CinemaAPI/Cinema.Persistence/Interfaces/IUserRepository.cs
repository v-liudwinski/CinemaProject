using Cinema.Domain.Models.Entities;
using Cinema.Domain.RequestFeatures;

namespace Cinema.Persistence.Interfaces;

public interface IUserRepository
{
    Task<PagedList<User>> GetAllUsersAsync(UserParameters userParameters);
    Task<User?> GetUserAsync(int id, bool trackChanges = false);
    Task<User?> GetUserInfoAsync(int id);
    void CreateUser(User user);
    void DeleteUser(User user);
    Task<User?> EmailExists(string email);
}