using Unyx.Domain.Entities;

namespace Unyx.Application.Interfaces.Services.Auth.Tokens;

public interface IRefreshTokenService
{
    Task<RefreshToken> GetRefreshTokenAsync(Guid userId);
}
