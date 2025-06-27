using Unyx.Application.Common.Enums;

namespace Unyx.Application.Interfaces.Services.Email;

public interface IEmailTemplateService
{
    Task<string> GenerateEmailBodyAsync<T>(EmailTemplateType templateType, T model);
}
