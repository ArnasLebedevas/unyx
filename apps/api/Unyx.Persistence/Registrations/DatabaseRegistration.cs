using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Unyx.Persistence.Registrations;

internal static class DatabaseRegistration
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<UnyxDbContext>(options => options.UseSqlServer(connectionString));

        return services;
    }
}
