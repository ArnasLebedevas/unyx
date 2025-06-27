using Unyx.Domain.Entities;

namespace Unyx.Application.Interfaces.Services.Email;

public interface IEmailVerificationLinkGenerator
{
    string GenerateLink(User user);
}
