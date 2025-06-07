using Unyx.Application.Common.Email;

namespace Unyx.Application.Interfaces.Services;

public interface IEmailService
{
    Task SendEmailAsync<T>(string to, T templateModel) where T : EmailTemplateModel;
}