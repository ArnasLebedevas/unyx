using Unyx.Domain.Entities;

namespace Unyx.Application.Interfaces.Security;

public interface IPasswordValidationService
{
    bool IsPasswordValid(User user, string password);
}
