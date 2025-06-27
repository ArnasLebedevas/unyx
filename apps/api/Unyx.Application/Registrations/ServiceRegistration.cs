using Microsoft.Extensions.DependencyInjection;
using Unyx.Application.Interfaces.Services.Auth;
using Unyx.Application.Interfaces.Services.Email;
using Unyx.Application.Interfaces.Services.Users;
using Unyx.Application.Services.Email;
using Unyx.Application.Services.Users;

namespace Unyx.Application.Registrations;

internal static class ServiceRegistration
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserValidationService, UserValidationService>();
        services.AddScoped<IEmailVerificationService, EmailVerificationService>();
        services.AddScoped<IEmailVerificationLinkGenerator, EmailVerificationLinkGenerator>();

        return services;
    }
}