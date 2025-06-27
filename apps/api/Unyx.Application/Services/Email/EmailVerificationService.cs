using Unyx.Application.Common.Email;
using Unyx.Application.Interfaces.Services.Email;
using Unyx.Domain.Entities;

namespace Unyx.Application.Services.Email;

internal class EmailVerificationService(IEmailService emailService, IEmailVerificationLinkGenerator linkGenerator) : IEmailVerificationService
{
    public async Task SendVerificationEmailAsync(User user)
    {
        var link = linkGenerator.GenerateLink(user);

        var template = new EmailVerificationTemplateModel
        {
            VerificationLink = link,
        };

        await emailService.SendEmailAsync(user.Email, template);
    }
}
