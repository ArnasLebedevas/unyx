using Microsoft.Extensions.Options;
using Unyx.Application.Abstractions.Security;
using Unyx.Application.Common.Exceptions;
using Unyx.Application.Common.Settings;
using Unyx.Application.Persistence.Read;
using Unyx.Domain.Entities;

namespace Unyx.Infrastructure.Security;

public class RefreshTokenService(ISecurityTokenGenerator securityTokenGenerator, IRefreshTokenReadRepository refreshTokenReadRepository, IOptions<JwtSettings> jwtSettings) : IRefreshTokenService
{
    private readonly int _refreshTokenExpiryDays = jwtSettings.Value.RefreshTokenExpiryDays;

    public async Task<RefreshToken> GetRefreshTokenAsync(Guid userId)
    {
        var existingToken = await refreshTokenReadRepository.GetByUserIdAsync(userId) ?? throw new RefreshTokenNotFoundException(userId);

        if (existingToken.IsActive) return existingToken;

        existingToken.IsRevoked = true;
        return CreateNewToken(existingToken);
    }

    private RefreshToken CreateNewToken(RefreshToken oldToken) => new()
    {
        Token = securityTokenGenerator.GenerateRefreshToken(),
        UserId = oldToken.UserId,
        ExpiresAt = DateTime.UtcNow.AddDays(_refreshTokenExpiryDays),
        IsRevoked = false,
    };
}
