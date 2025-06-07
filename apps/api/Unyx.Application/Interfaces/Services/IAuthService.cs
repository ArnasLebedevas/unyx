using Unyx.Application.Features.Auth.DTOs;
using Unyx.Domain.Entities;

namespace Unyx.Application.Interfaces.Services;

public interface IAuthService
{
    Task<User?> ValidateUserCredentialsAsync(string email, string password);
    AuthResponseDto CreateAuthResponse(User user, string refreshToken);
}
