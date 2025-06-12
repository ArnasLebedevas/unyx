using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unyx.Application.Common.Settings;

namespace Unyx.Infrastructure.Registrations;

public static class ConfigRegistration
{
    public static IServiceCollection AddConfigSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        services.Configure<FrontendSettings>(configuration.GetSection("FrontendSettings"));

        return services;
    }
}
