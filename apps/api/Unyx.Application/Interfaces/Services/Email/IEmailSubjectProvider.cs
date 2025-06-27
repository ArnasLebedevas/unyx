using Unyx.Application.Common.Enums;

namespace Unyx.Application.Interfaces.Services.Email;

public interface IEmailSubjectProvider
{
    string GetSubject(EmailTemplateType templateType);
}