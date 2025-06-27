using Microsoft.AspNetCore.Identity;
using Unyx.Application.Interfaces.Services.Users;
using Unyx.Application.Persistence.Read;
using Unyx.Domain.Entities;

namespace Unyx.Application.Services.Users;

internal sealed class UserValidationService(IUserReadRepository userReadRepository, IPasswordHasher<User> passwordHasher) : IUserValidationService
{
    public async Task<User?> ValidateCredentialsAsync(string email, string password)
    {
        var user = await userReadRepository.GetUserByEmailAsync(email);
        if (user == null || !IsPasswordValid(user, password)) return null;

        return user;
    }

    private bool IsPasswordValid(User user, string password)
    {
        if (string.IsNullOrWhiteSpace(user.PasswordHash)) return false;

        var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
        return result == PasswordVerificationResult.Success;
    }
}
