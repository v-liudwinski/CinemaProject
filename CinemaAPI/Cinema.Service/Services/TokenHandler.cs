using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Cinema.Domain.ExceptionModels;
using Cinema.Domain.Models.Consts;
using Cinema.Domain.Models.Entities;
using Cinema.Domain.Models.ViewModels;
using Cinema.Persistence.Interfaces;
using Cinema.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Cinema.Service.Services;

public class TokenHandler : ITokenHandler
{
    private readonly IConfiguration _configuration;
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _loggerManager;

    public TokenHandler(IConfiguration configuration, IRepositoryManager repository, IMapper mapper, ILoggerManager loggerManager)
    {
        _configuration = configuration;
        _repository = repository;
        _mapper = mapper;
        _loggerManager = loggerManager;
    }

    public async Task<string> CreateTokenAsync(UserViewModel user)
    {
        // Create Claims
        user.UserRefreshToken ??= new UserRefreshToken
        {
            Id = 0,
            Token = null,
            Expires = default,
            UserId = 0,
            User = null
        };
        
        var claims = new List<Claim>
        {
            new("id", user.Id.ToString()),
            new("refreshTokenId", user.UserRefreshToken.Id.ToString()),
            new(ClaimTypes.GivenName, user.FirstName),
            new(ClaimTypes.Surname, user.LastName),
            new(ClaimTypes.Email, user.Email),
            new("role", user.Role.RoleName.ToString())
        };

        // Token creation
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(3),
            signingCredentials: credentials
        );
        return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
    }

    public async Task<RefreshResponse> Refresh(string expiredToken)
    {
        UserRefreshToken refreshToken;
        int userId;
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

        try
        {
            tokenHandler.ValidateToken(expiredToken, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out var validatedToken);

            var jwtToken = validatedToken as JwtSecurityToken;
            userId = int.Parse(jwtToken!.Claims
                .FirstOrDefault(x => x.Type == "id")!.Value);
            
            refreshToken = new UserRefreshToken
            {
                Token = Guid.NewGuid().ToString(),
                Expires = DateTime.Now.AddDays(30),
                UserId = userId
            };

            var refreshTokenId = int.Parse(jwtToken!.Claims
                .FirstOrDefault(x => x.Type == "refreshTokenId")!.Value);

            var tokenForUpdate = await _repository.RefreshToken.GetRefreshTokensAsync(refreshTokenId, true);
            
            switch (tokenForUpdate)
            {
                case not null:
                    tokenForUpdate.Token = refreshToken.Token;
                    tokenForUpdate.Expires = refreshToken.Expires;
                    await _repository.SaveAsync();
                    break;
                case null:
                    _repository.RefreshToken.GenerateRefreshTokens(refreshToken);
                    await _repository.SaveAsync();
                    break;
            }
        }
        catch (Exception)
        {
            throw new BadRequestException("Invalid token!");
        }
        
        var user = await _repository.User.GetUserAsync(userId);
        
        if (user is null)
        {
            _loggerManager.LogError(ConstError.ERROR_BY_ID);
            throw new NotFoundException(ConstError.GetErrorForException(nameof(User), userId));
        }
        
        user.UserRefreshToken = refreshToken;
        await _repository.SaveAsync();
        
        var userAfterUpdate = await _repository.User.GetUserAsync(userId);
        var userViewModel = _mapper.Map<UserViewModel>(userAfterUpdate);
        var newToken = await CreateTokenAsync(userViewModel);

        return new RefreshResponse
        {
            NewJwtToken = newToken,
            RefreshToken = refreshToken.Token
        };
    }
}