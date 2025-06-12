using System.Security.Claims;

namespace Unyx.Application.Interfaces.Security;

public interface ITokenService
{
    string GenerateToken(IEnumerable<Claim> claims, DateTime expires);
    ClaimsPrincipal ValidateToken(string token);
}