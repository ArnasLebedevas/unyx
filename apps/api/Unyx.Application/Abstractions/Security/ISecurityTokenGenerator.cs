namespace Unyx.Application.Abstractions.Security;

public interface ISecurityTokenGenerator
{
    string GenerateVerificationCode();
    string GenerateRefreshToken();
}