using Microsoft.Extensions.DependencyInjection;
using Unyx.Application.Interfaces.Services.Auth.External;
using Unyx.Application.Interfaces.Services.Auth.Tokens;
using Unyx.Application.Interfaces.Services.Email;
using Unyx.Infrastructure.Auth.External;
using Unyx.Infrastructure.Auth.Tokens;
using Unyx.Infrastructure.Services.Email;
using Unyx.Infrastructure.Services.Users;

namespace Unyx.Infrastructure.Registrations;

public static class ServiceRegistration
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IExternalSignInService, ExternalSignInService>();
        services.AddScoped<IAuthProviderStrategy, GoogleAuthService>();

        services.AddScoped<ISecurityTokenGenerator, SecurityTokenGenerator>();
        services.AddScoped<IRefreshTokenService, RefreshTokenService>();

        services.AddScoped<IEmailTemplateService, EmailTemplateService>();
        services.AddScoped<IEmailSubjectProvider, EmailSubjectProvider>();
        services.AddScoped<IEmailService, EmailService>();

        services.AddScoped<IAuthTokenService, AuthTokenService>();
        services.AddScoped<IEmailVerificationTokenService, EmailVerificationTokenService>();

        return services;
    }
}