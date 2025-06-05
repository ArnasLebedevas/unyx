using Unyx.Application.Common.DTOs;
using Unyx.Domain.Entities;

namespace Unyx.Application.Abstractions.Services;

public interface IAuthService
{
    Task<User?> ValidateUserCredentialsAsync(string email, string password);
    AuthResponseDto CreateAuthResponse(User user, string refreshToken);
}
