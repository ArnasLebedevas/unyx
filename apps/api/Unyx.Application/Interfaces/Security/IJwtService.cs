using Unyx.Domain.Entities;

namespace Unyx.Application.Interfaces.Security;

public interface IJwtService
{
    string GenerateToken(User user);
}