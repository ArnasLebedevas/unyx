using Microsoft.Extensions.Options;
using System.Security.Claims;
using Unyx.Application.Common.Exceptions;
using Unyx.Application.Common.Messages;
using Unyx.Application.Common.Settings;
using Unyx.Application.Interfaces.Services.Auth.Tokens;

namespace Unyx.Infrastructure.Auth.Tokens;

public class EmailVerificationTokenService(ITokenService tokenService, IOptions<JwtSettings> settings) : IEmailVerificationTokenService
{
    private readonly int _expiryMinutes = settings.Value.EmailVerificationTokenExpiryMinutes;

    public string GenerateToken(Guid userId)
    {
        var claims = new[] { new Claim(ClaimTypes.NameIdentifier, userId.ToString()) };
        var expires = DateTime.UtcNow.AddMinutes(_expiryMinutes);
        return tokenService.GenerateToken(claims, expires);
    }

    public Guid ValidateToken(string token)
    {
        var principal = tokenService.ValidateToken(token);

        var claim = principal.FindFirstValue(ClaimTypes.NameIdentifier)
            ?? throw new InvalidTokenException(ErrorMessages.InvalidEmailVerificationToken);

        return Guid.Parse(claim);
    }
}
