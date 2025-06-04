using Microsoft.Extensions.DependencyInjection;

namespace Unyx.Application.Registrations;

public static class ApplicationRegistration
{
    public static IServiceCollection AddApplication(this IServiceCollection services) =>
        services
               .AddMappingServices()
               .AddMediatRServices();
}
