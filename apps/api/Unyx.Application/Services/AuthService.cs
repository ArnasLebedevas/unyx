using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Unyx.Application.Features.Auth.DTOs;
using Unyx.Application.Interfaces.Security;
using Unyx.Application.Interfaces.Services;
using Unyx.Application.Persistence.Read;
using Unyx.Domain.Entities;

namespace Unyx.Application.Services;

internal class AuthService(IUserReadRepository userReadRepository, IPasswordHasher<User> passwordHasher, IAuthTokenService authTokenService, IMapper mapper) : IAuthService
{
    public async Task<User?> ValidateUserCredentialsAsync(string email, string password)
    {
        var user = await userReadRepository.GetUserByEmailAsync(email);
        if (user == null || !IsPasswordVerified(user, password)) return null;

        return user;
    }

    public AuthResponseDto CreateAuthResponse(User user, string refreshToken)
    {
        var response = mapper.Map<AuthResponseDto>(user);
        response.Token = authTokenService.GenerateToken(user);
        response.RefreshToken = refreshToken;
        return response;
    }

    private bool IsPasswordVerified(User user, string password) =>
        user.PasswordHash is not null &&
        passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password) == PasswordVerificationResult.Success;
}
