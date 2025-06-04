using Microsoft.Extensions.DependencyInjection;
using Unyx.Application.Persistence.Read;
using Unyx.Application.Persistence.Write;
using Unyx.Application.Persistence;
using Unyx.Persistence.Repositories.Read;
using Unyx.Persistence.Repositories.Write;
using Unyx.Persistence.Repositories;

namespace Unyx.Persistence.Registrations;

public static class RepositoryRegistration
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

        services.AddScoped<IUserReadRepository, UserReadRepository>();
        services.AddScoped<IRefreshTokenReadRepository, RefreshTokenReadRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}