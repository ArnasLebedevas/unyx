using Unyx.Application.Features.Auth.DTOs;
using Unyx.Application.Interfaces.Services.Auth.External;
using Unyx.Domain.Enums;

namespace Unyx.Infrastructure.Auth.External;

public class GoogleAuthService : IAuthProviderStrategy
{
    public AuthProvider Provider => AuthProvider.Google;

    public Task<ExternalUserInfo?> GetUserInfoAsync(string accessToken)
    {
        throw new NotImplementedException();
    }
}
