namespace Unyx.Application.Interfaces.Services.Auth.Tokens;

public interface ISecurityTokenGenerator
{
    string GenerateVerificationCode();
    string GenerateRefreshToken();
}