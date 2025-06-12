using Unyx.Domain.Entities;

namespace Unyx.Application.Interfaces.Security;

public interface IAuthTokenService
{
    string GenerateToken(User user);
}
