using System.Reflection;
using System.Text.RegularExpressions;
using Unyx.Application.Common.Enums;
using Unyx.Application.Interfaces.Services.Email;

namespace Unyx.Infrastructure.Services.Email;

public class EmailTemplateService : IEmailTemplateService
{
    public async Task<string> GenerateEmailBodyAsync<T>(EmailTemplateType templateType, T model)
    {
        var templateName = templateType.ToString();
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = $"Unyx.Infrastructure.Templates.{templateName}.cshtml";

        using var stream = assembly.GetManifestResourceStream(resourceName)
            ?? throw new FileNotFoundException($"Embedded email template '{templateName}' not found.");

        using var reader = new StreamReader(stream);
        var template = await reader.ReadToEndAsync();

        foreach (var prop in typeof(T).GetProperties())
        {
            var value = prop.GetValue(model)?.ToString() ?? string.Empty;
            template = Regex.Replace(template, $"{{{{{prop.Name}}}}}", value, RegexOptions.IgnoreCase);
        }

        return template;
    }
}
