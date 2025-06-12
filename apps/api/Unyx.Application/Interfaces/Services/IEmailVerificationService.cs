using Unyx.Domain.Entities;

namespace Unyx.Application.Interfaces.Services;

internal interface IEmailVerificationService
{
    Task SendVerificationEmailAsync(User user);
}
