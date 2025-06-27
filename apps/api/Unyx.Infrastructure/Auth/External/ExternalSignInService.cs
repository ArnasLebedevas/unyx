using Unyx.Application.Common.Exceptions;
using Unyx.Application.Features.Auth.DTOs;
using Unyx.Application.Interfaces.Services.Auth.External;
using Unyx.Domain.Enums;

namespace Unyx.Infrastructure.Auth.External;

public class ExternalSignInService(IEnumerable<IAuthProviderStrategy> providers) : IExternalSignInService
{
    public async Task<ExternalUserInfo?> GetUserInfoAsync(AuthProvider provider, string accessToken)
    {
        var strategy = providers.FirstOrDefault(p => p.Provider == provider) 
            ?? throw new UnsupportedAuthProviderException(provider);

        return await strategy.GetUserInfoAsync(accessToken);
    }
}