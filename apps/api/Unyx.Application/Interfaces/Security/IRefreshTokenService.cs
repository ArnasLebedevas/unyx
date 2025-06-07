using Unyx.Domain.Entities;

namespace Unyx.Application.Interfaces.Security;

public interface IRefreshTokenService
{
    Task<RefreshToken> GetRefreshTokenAsync(Guid userId);
}
