using Unyx.Application.Common.Enums;

namespace Unyx.Application.Abstractions.Services;

public interface IEmailTemplateService
{
    Task<string> GenerateEmailBodyAsync<T>(EmailTemplateType templateType, T model);
    string GetSubject(EmailTemplateType templateType);
}
