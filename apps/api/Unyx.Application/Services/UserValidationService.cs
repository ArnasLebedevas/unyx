using Unyx.Application.Interfaces.Security;
using Unyx.Application.Interfaces.Services;
using Unyx.Application.Persistence.Read;
using Unyx.Domain.Entities;

namespace Unyx.Application.Services;

internal sealed class UserValidationService(IUserReadRepository userReadRepository, IPasswordValidationService passwordValidationService) : IUserValidationService
{
    public async Task<User?> ValidateCredentialsAsync(string email, string password)
    {
        var user = await userReadRepository.GetUserByEmailAsync(email);
        if (user == null || !passwordValidationService.IsPasswordValid(user, password))
            return null;

        return user;
    }
}
