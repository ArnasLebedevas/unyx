using Unyx.Application.Features.Auth.DTOs;
using Unyx.Domain.Enums;

namespace Unyx.Application.Interfaces.Services.Auth.External;

public interface IAuthProviderStrategy
{
    AuthProvider Provider { get; }
    Task<ExternalUserInfo?> GetUserInfoAsync(string accessToken);
}
