using Microsoft.Extensions.DependencyInjection;
using Unyx.Application.Features.Auth.SignUp;

namespace Unyx.Application.Registrations;

internal static class MappingRegistration
{
    public static IServiceCollection AddMappingServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(SignUpMapper));

        return services;
    }
}
