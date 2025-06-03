using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Unyx.Domain.Entities;
using Unyx.Domain.Enums;

namespace Unyx.Persistence.Configurations;

internal sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.RoleType)
            .HasConversion<string>()
            .IsRequired();

        builder.HasIndex(r => r.RoleType).IsUnique();

        builder.HasMany(r => r.Users)
            .WithOne(u => u.Role)
            .HasForeignKey(u => u.RoleId);

        builder.HasData(
            new Role { Id = Guid.NewGuid(), RoleType = RoleType.User },
            new Role { Id = Guid.NewGuid(), RoleType = RoleType.Admin }
        );
    }
}
