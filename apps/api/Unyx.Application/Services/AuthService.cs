using AutoMapper;
using Unyx.Application.Features.Auth.DTOs;
using Unyx.Application.Interfaces.Security;
using Unyx.Application.Interfaces.Services;
using Unyx.Domain.Entities;

namespace Unyx.Application.Services;

internal sealed class AuthService(IAuthTokenService authTokenService, IMapper mapper) : IAuthService
{
    public AuthResponseDto CreateAuthResponse(User user, string refreshToken)
    {
        var response = mapper.Map<AuthResponseDto>(user);
        response.Token = authTokenService.GenerateToken(user);
        response.RefreshToken = refreshToken;
        return response;
    }
}
