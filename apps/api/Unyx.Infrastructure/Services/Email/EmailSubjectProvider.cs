using Unyx.Application.Common.Enums;
using Unyx.Application.Common.Messages;
using Unyx.Application.Interfaces.Services.Email;

namespace Unyx.Infrastructure.Services.Email;

public class EmailSubjectProvider : IEmailSubjectProvider
{
    public string GetSubject(EmailTemplateType templateType) => templateType switch
    {
        EmailTemplateType.EmailVerification => "Verify Your Account",
        _ => throw new ArgumentOutOfRangeException(nameof(templateType), templateType, ErrorMessages.UnSupportedTemplate)
    };
}