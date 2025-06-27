using Unyx.Domain.Entities;

namespace Unyx.Application.Interfaces.Services.Email;

internal interface IEmailVerificationService
{
    Task SendVerificationEmailAsync(User user);
}
