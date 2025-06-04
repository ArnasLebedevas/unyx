using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Unyx.Infrastructure.Registrations;

public static class CorsRegistration
{
    public static IServiceCollection AddCorsConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var allowedOrigins = configuration.GetSection("Cors:AllowedOrigins").GetChildren().Select(c => c.Value).ToArray();
        var policyName = configuration["Cors:PolicyName"];

        services.AddCors(options =>
        {
            options.AddPolicy(policyName, policy =>
            {
                policy.WithOrigins(allowedOrigins)
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                      .AllowCredentials();
            });
        });

        return services;
    }
}