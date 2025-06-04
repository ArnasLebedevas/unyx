using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Unyx.Domain.Entities;

namespace Unyx.Persistence;

public class UnyxDbContext(DbContextOptions<UnyxDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Username> Usernames => Set<Username>();
    public DbSet<ExternalClaim> ExternalClaims => Set<ExternalClaim>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}