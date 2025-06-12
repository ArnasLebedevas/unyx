namespace Unyx.Application.Interfaces.Security;

public interface IEmailVerificationTokenService
{
    string GenerateToken(Guid userId);
    Guid ValidateToken(string token);
}