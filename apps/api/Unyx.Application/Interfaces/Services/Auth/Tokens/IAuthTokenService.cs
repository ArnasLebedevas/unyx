using Unyx.Domain.Entities;

namespace Unyx.Application.Interfaces.Services.Auth.Tokens;

public interface IAuthTokenService
{
    string GenerateToken(User user);
}
