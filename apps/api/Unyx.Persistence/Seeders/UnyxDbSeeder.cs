using Microsoft.EntityFrameworkCore;
using Unyx.Domain.Constants;
using Unyx.Domain.Entities;
using Unyx.Domain.Enums;

namespace Unyx.Persistence.Seeders;

public static class UnyxDbSeeder
{
    public static async Task SeedAsync(UnyxDbContext context, CancellationToken cancellationToken = default)
    {
        await context.Database.MigrateAsync(cancellationToken);
        await SeedRolesAsync(context, cancellationToken);
    }

    private static async Task SeedRolesAsync(UnyxDbContext context, CancellationToken cancellationToken)
    {
        if (await context.Roles.AnyAsync(cancellationToken)) return;

        var roles = new List<Role>
        {
            new() { Id = RoleIds.User, RoleType = RoleType.User },
            new() { Id = RoleIds.Admin, RoleType = RoleType.Admin }
        };

        context.Roles.AddRange(roles);
        await context.SaveChangesAsync(cancellationToken);
    }
}