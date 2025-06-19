using Unyx.Application.Common.Enums;

namespace Unyx.Application.Common.Email;

internal class EmailVerificationTemplateModel : EmailTemplateModel
{
    public required string VerificationLink { get; set; }

    public override EmailTemplateType TemplateType => EmailTemplateType.EmailVerification;
}