using AutoMapper;
using Unyx.Application.Features.Auth.DTOs;
using Unyx.Application.Interfaces.Services.Auth;
using Unyx.Application.Interfaces.Services.Auth.Tokens;
using Unyx.Domain.Entities;

namespace Unyx.Application.Services.Users;

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
