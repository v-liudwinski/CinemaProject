using Cinema.Domain.Models.Entities;

namespace Cinema.Persistence.Interfaces;

public interface IUserRefreshTokenRepository
{
    Task<List<UserRefreshToken>> GetAllRefreshTokensAsync();
    Task<UserRefreshToken?> GetRefreshTokensAsync(int id, bool trackChanges = false);
    void GenerateRefreshTokens(UserRefreshToken refreshToken);
    void DeleteRefreshTokens(UserRefreshToken refreshToken);
}