using Microsoft.Extensions.DependencyInjection;
using Unyx.Application.Features.Auth.SignUp;

namespace Unyx.Application.Registrations;

public static class MappingRegistration
{
    public static IServiceCollection AddMappingServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(SignUpMapping));

        return services;
    }
}
