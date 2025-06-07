using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using Unyx.Application.Common.Email;
using Unyx.Application.Common.Messages;
using Unyx.Application.Common.Settings;
using Unyx.Application.Common.Exceptions;
using Unyx.Application.Interfaces.Services;

namespace Unyx.Infrastructure.Services;

public class EmailService(IOptions<EmailSettings> emailSettings, ILogger<EmailService> logger, IEmailTemplateService emailTemplateService) : IEmailService
{
    private readonly EmailSettings _emailSettings = emailSettings.Value;

    public async Task SendEmailAsync<T>(string to, T templateModel) where T : EmailTemplateModel
    {
        var subject = emailTemplateService.GetSubject(templateModel.TemplateType);
        var body = await emailTemplateService.GenerateEmailBodyAsync(templateModel.TemplateType, templateModel);

        using var smtpClient = new SmtpClient(_emailSettings.Server, _emailSettings.Port)
        {
            Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.Password),
            EnableSsl = true
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(_emailSettings.FromEmail),
            Subject = subject,
            Body = body,
            IsBodyHtml = true
        };

        mailMessage.To.Add(to);

        try
        {
            await smtpClient.SendMailAsync(mailMessage);
            logger.LogInformation("Email sent successfully to {Recipient}", to);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to send email to {Recipient}", to);
            throw new EmailSendFailureException(ErrorMessages.EmailServiceNetworkError, ex);
        }
    }
}

