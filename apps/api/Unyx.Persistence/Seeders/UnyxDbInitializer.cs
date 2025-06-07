using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Unyx.Application.Common.Messages;

namespace Unyx.Persistence.Seeders;

public static class UnyxDbInitializer
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<UnyxDbContext>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<UnyxDbContext>>();

        try
        {
            await UnyxDbSeeder.SeedAsync(dbContext);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ErrorMessages.SeedingDatabaseError);
            throw;
        }
    }
}