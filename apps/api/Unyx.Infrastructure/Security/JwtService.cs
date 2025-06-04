using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Unyx.Application.Abstractions.Security;
using Unyx.Application.Common.Settings;
using Unyx.Domain.Entities;

namespace Unyx.Infrastructure.Security;

public class JwtService(IOptions<JwtSettings> settings) : IJwtService
{
    private readonly byte[] _key = Encoding.UTF8.GetBytes(settings.Value.Secret);
    private readonly int _tokenExpiryMinutes = settings.Value.TokenExpiryMinutes;

    public string GenerateToken(User user)
    {
        var handler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
            [
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.RoleType.ToString()),
            ]),
            Expires = DateTime.UtcNow.AddMinutes(_tokenExpiryMinutes),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_key), SecurityAlgorithms.HmacSha256)
        };

        var token = handler.CreateToken(tokenDescriptor);

        return handler.WriteToken(token);
    }
}