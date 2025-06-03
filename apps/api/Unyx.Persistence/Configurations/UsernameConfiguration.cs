using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Unyx.Domain.Entities;

namespace Unyx.Persistence.Configurations;

internal sealed class UsernameConfiguration : IEntityTypeConfiguration<Username>
{
    public void Configure(EntityTypeBuilder<Username> builder)
    {
        builder.HasKey(ec => ec.Id);
    }
}