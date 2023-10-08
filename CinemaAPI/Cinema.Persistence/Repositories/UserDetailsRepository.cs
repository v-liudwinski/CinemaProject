using Cinema.Domain.Models.Entities;
using Cinema.Persistence.Data;
using Cinema.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Persistence.Repositories;

public class UserDetailsRepository : RepositoryBase<UserDetails>, IUserDetailsRepository
{
    public UserDetailsRepository(RepositoryContext repositoryContext) 
        : base(repositoryContext)
    { }

    public async Task<UserDetails?> GetUserDetailsAsync(int id)
    {
        return await FindByCondition(x => x.Id == id, true)
            .FirstOrDefaultAsync();
    }
}
