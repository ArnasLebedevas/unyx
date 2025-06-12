using Unyx.Domain.Entities;

namespace Unyx.Application.Interfaces.Services;

public interface IEmailVerificationLinkGenerator
{
    string GenerateLink(User user);
}
