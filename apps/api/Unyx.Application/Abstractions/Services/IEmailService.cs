using Unyx.Application.Common.Email;

namespace Unyx.Application.Abstractions.Services;

public interface IEmailService
{
    Task SendEmailAsync<T>(string to, T templateModel) where T : EmailTemplateModel;
}