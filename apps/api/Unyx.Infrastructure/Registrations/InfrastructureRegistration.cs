using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Unyx.Infrastructure.Registrations;

public static class InfrastructureRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) =>
        services
               .AddCorsConfiguration(configuration)
               .AddConfigSettings(configuration)
               .AddAuthServices(configuration)
               .AddServices();
}
