using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.ViewModels;

namespace Cinema.Service.Interfaces;

public interface IAuthenticatorService
{
    Task<UserViewModel> AuthenticateAsync(LoginRequest loginRequest);
}