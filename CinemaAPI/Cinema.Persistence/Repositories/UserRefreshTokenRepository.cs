using Cinema.Domain.Models.Entities;
using Cinema.Persistence.Data;
using Cinema.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Persistence.Repositories;

public class UserRefreshTokenRepository : RepositoryBase<UserRefreshToken>, IUserRefreshTokenRepository
{
    public UserRefreshTokenRepository(RepositoryContext repositoryContext) 
        : base(repositoryContext)
    { }

    public async Task<List<UserRefreshToken>> GetAllRefreshTokensAsync()
    {
        return await FindAll()
            .ToListAsync();
    }

    public async Task<UserRefreshToken?> GetRefreshTokensAsync(int id, bool trackChanges = false)
    {
        return await FindByCondition(x => x.Id == id, false)
            .FirstOrDefaultAsync();
    }

    public void GenerateRefreshTokens(UserRefreshToken refreshToken)
    {
        Create(refreshToken);
    }

    public void DeleteRefreshTokens(UserRefreshToken refreshToken)
    {
        Delete(refreshToken);
    }
}