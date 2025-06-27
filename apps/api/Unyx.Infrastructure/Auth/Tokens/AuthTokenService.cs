using Microsoft.Extensions.Options;
using System.Security.Claims;
using Unyx.Application.Common.Settings;
using Unyx.Application.Interfaces.Services.Auth.Tokens;
using Unyx.Domain.Entities;

namespace Unyx.Infrastructure.Auth.Tokens;

public class AuthTokenService(ITokenService tokenService, IOptions<JwtSettings> options) : IAuthTokenService
{
    private readonly int _expiryMinutes = options.Value.TokenExpiryMinutes;

    public string GenerateToken(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Role, user.Role.RoleType.ToString())
        };

        var expireDate = DateTime.UtcNow.AddMinutes(_expiryMinutes);

        return tokenService.GenerateToken(claims, expireDate);
    }
}
