using Unyx.Application.Features.Auth.DTOs;
using Unyx.Domain.Entities;

namespace Unyx.Application.Interfaces.Services.Auth;

internal interface IAuthService
{
    AuthResponseDto CreateAuthResponse(User user, string refreshToken);
}
