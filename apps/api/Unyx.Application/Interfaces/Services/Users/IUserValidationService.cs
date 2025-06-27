using Unyx.Domain.Entities;

namespace Unyx.Application.Interfaces.Services.Users;

internal interface IUserValidationService
{
    Task<User?> ValidateCredentialsAsync(string email, string password);
}
