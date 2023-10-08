using Cinema.Domain.Models.ViewModels;

namespace Cinema.Service.Interfaces;

public interface ITokenHandler
{
    Task<string> CreateTokenAsync(UserViewModel user);
    Task<RefreshResponse> Refresh(string expiredToken);
}