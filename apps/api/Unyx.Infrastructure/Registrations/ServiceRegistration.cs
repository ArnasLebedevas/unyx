using Microsoft.Extensions.DependencyInjection;
using Unyx.Application.Abstractions.Security;
using Unyx.Infrastructure.Security;

namespace Unyx.Infrastructure.Registrations;

public static class ServiceRegistration
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ISecurityTokenGenerator, SecurityTokenGenerator>();
        services.AddScoped<IRefreshTokenService, RefreshTokenService>();

        return services;
    }
}