using Microsoft.AspNetCore.Identity;
using Unyx.Application.Interfaces.Security;
using Unyx.Domain.Entities;

namespace Unyx.Infrastructure.Security;

public class PasswordValidationService(IPasswordHasher<User> passwordHasher) : IPasswordValidationService
{
    public bool IsPasswordValid(User user, string password)
    {
        return user.PasswordHash is not null && passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password) == PasswordVerificationResult.Success;
    }
}
