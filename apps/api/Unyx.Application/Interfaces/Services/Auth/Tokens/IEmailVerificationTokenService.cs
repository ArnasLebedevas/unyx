namespace Unyx.Application.Interfaces.Services.Auth.Tokens;

public interface IEmailVerificationTokenService
{
    string GenerateToken(Guid userId);
    Guid ValidateToken(string token);
}