using Cinema.Domain.Models.DTOs;
using Cinema.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.UI.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ITokenHandler _tokenHandler;
    private readonly IAuthenticatorService _authenticator;

    public AuthController(ITokenHandler tokenHandler, IAuthenticatorService authenticator)
    {
        _tokenHandler = tokenHandler;
        _authenticator = authenticator;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Index([FromBody] LoginRequest loginRequest)
    {
        var user = await _authenticator.AuthenticateAsync(loginRequest);
        var token = await _tokenHandler.CreateTokenAsync(user);
        return Ok(token);
    }
    
    [HttpPost]
    [Route("refresh")]
    public async Task<IActionResult> Refresh(string expiredToken)
    {
        var refreshResponse = await _tokenHandler.Refresh(expiredToken);
        return Ok(refreshResponse);
    }
}