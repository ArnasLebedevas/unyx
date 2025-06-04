using Unyx.Domain.Entities;

namespace Unyx.Application.Abstractions.Security;

public interface IJwtService
{
    string GenerateToken(User user);
}