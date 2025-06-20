﻿using Microsoft.Extensions.DependencyInjection;
using Unyx.Application.Interfaces.Services;
using Unyx.Application.Services;

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