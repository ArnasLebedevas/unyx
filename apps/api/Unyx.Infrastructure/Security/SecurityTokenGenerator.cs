using System.Security.Cryptography;
using Unyx.Application.Interfaces.Security;

namespace Unyx.Infrastructure.Security;

public class SecurityTokenGenerator : ISecurityTokenGenerator
{
    private const int MinCode = 100000;
    private const int MaxCode = 999999;

    public string GenerateVerificationCode() 
    { 
        return RandomNumberGenerator.GetInt32(MinCode, MaxCode + 1).ToString(); 
    }

    public string GenerateRefreshToken()
    {
        var randomBytes = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomBytes);
        return Convert.ToBase64String(randomBytes);
    }
}