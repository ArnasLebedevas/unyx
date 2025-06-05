using Microsoft.Extensions.DependencyInjection;
using Unyx.Application.Abstractions.Services;
using Unyx.Application.Services;

namespace Unyx.Application.Registrations;

public static class ServiceRegistration
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}