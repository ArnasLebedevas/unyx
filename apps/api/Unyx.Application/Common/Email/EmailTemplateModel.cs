using Unyx.Application.Common.Enums;

namespace Unyx.Application.Common.Email;

public abstract class EmailTemplateModel
{
    public abstract EmailTemplateType TemplateType { get; }
}