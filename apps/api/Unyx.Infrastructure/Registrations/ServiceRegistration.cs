using Microsoft.Extensions.DependencyInjection;
using Unyx.Application.Interfaces.Security;
using Unyx.Application.Interfaces.Services;
using Unyx.Infrastructure.Security;
using Unyx.Infrastructure.Services;

namespace Unyx.Infrastructure.Registrations;

public static class ServiceRegistration
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ISecurityTokenGenerator, SecurityTokenGenerator>();
        services.AddScoped<IRefreshTokenService, RefreshTokenService>();
        services.AddScoped<IEmailTemplateService, EmailTemplateService>();
        services.AddScoped<IEmailService, EmailService>();

        return services;
    }
}