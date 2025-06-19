using Unyx.Domain.Entities;

namespace Unyx.Application.Interfaces.Services;

internal interface IUserValidationService
{
    Task<User?> ValidateCredentialsAsync(string email, string password);
}
