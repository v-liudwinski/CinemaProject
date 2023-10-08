using Cinema.Domain.Models.Entities;
using Cinema.Domain.RequestFeatures;
using Cinema.Persistence.Data;
using Cinema.Persistence.Extensions;
using Cinema.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Persistence.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(RepositoryContext repositoryContext) 
        : base(repositoryContext)
    { }

    public async Task<PagedList<User>> GetAllUsersAsync(UserParameters userParameters)
    {
        var users = await FindAll()
            .Include(x => x.Role)
            .Include(x => x.UserRefreshToken)
            .OrderBy(x => x.LastName)
            .ThenBy(x => x.FirstName)
            .Search(userParameters.SearchTerm)
            .Skip((userParameters.PageNumber - 1) * userParameters.PageSize)
            .Take(userParameters.PageSize)
            .ToListAsync();

        var count = await FindAll().CountAsync();
        return new PagedList<User>(users, count, userParameters.PageNumber, userParameters.PageSize);
    }

    public async Task<User?> GetUserAsync(int id, bool trackChanges = false)
    {
        return await FindByCondition(x => x.Id == id, trackChanges)
            .Include(x => x.UserDetails)
            .Include(x => x.Role)
            .Include(x => x.UserRefreshToken)
            .FirstOrDefaultAsync();
    }

    public void CreateUser(User user)
    {
        user.RoleId = 2;
        Create(user);
    }

    public void DeleteUser(User user)
    {
        Delete(user);
    }

    public async Task<User?> GetUserInfoAsync(int id)
    {
        return await FindByCondition(x => x.Id == id, false)
            .Include(x => x.Role)
                .Include(x => x.UserDetails)
                    .ThenInclude(x => x.Reviews)
                .Include(x => x.UserDetails)
                    .ThenInclude(x => x.Favourites)
            .FirstOrDefaultAsync();
    }

    public async Task<User?> EmailExists(string email)
    {
        return await FindByCondition(x => x.Email == email, false)
            .FirstOrDefaultAsync();
    }
}