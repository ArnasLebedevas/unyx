namespace Unyx.Application.Interfaces.Security;

public interface ISecurityTokenGenerator
{
    string GenerateVerificationCode();
    string GenerateRefreshToken();
}