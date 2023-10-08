using AutoMapper;
using Cinema.Domain.ExceptionModels;
using Cinema.Domain.Models.Consts;
using Cinema.Domain.Models.DTOs;
using Cinema.Domain.Models.Entities;
using Cinema.Domain.Models.ViewModels;
using Cinema.Persistence.Interfaces;
using Cinema.Service.Interfaces;

namespace Cinema.Service.Services;

public class AuthenticatorService : IAuthenticatorService
{
    private readonly IAuthenticatorRepository _authenticator;
    private readonly ILoggerManager _loggerManager;
    private readonly IMapper _mapper;

    public AuthenticatorService(IAuthenticatorRepository authenticator, ILoggerManager loggerManager, IMapper mapper)
    {
        _authenticator = authenticator;
        _loggerManager = loggerManager;
        _mapper = mapper;
    }

    public async Task<UserViewModel> AuthenticateAsync(LoginRequest loginRequest)
    {
        var user = await _authenticator.AuthenticateAsync(loginRequest.Email, loginRequest.Password);

        if (user is null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_CREDENTIALS);
            throw new NotFoundException
                (ConstError.GetCredentialsErrorExceptionMessage
                    (nameof(User), loginRequest.Email, loginRequest.Password));
        }

        return _mapper.Map<UserViewModel>(user);
    }
}