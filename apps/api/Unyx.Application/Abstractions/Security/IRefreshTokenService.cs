using Unyx.Domain.Entities;

namespace Unyx.Application.Abstractions.Security;

public interface IRefreshTokenService
{
    Task<RefreshToken> GetRefreshTokenAsync(Guid userId);
}
