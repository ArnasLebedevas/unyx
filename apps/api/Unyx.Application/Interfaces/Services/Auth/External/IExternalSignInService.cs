using Unyx.Application.Features.Auth.DTOs;
using Unyx.Domain.Enums;

namespace Unyx.Application.Interfaces.Services.Auth.External;

public interface IExternalSignInService
{
    Task<ExternalUserInfo?> GetUserInfoAsync(AuthProvider provider, string accessToken);
}