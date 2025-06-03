using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Unyx.Domain.Entities;

namespace Unyx.Persistence.Configurations;

internal sealed class UsernameConfiguration : IEntityTypeConfiguration<Username>
{
    public void Configure(EntityTypeBuilder<Username> builder)
    {
        builder.HasKey(ec => ec.Id);

        builder.Property(x => x.Value)
           .IsRequired()
           .HasMaxLength(64);

        builder.Property(x => x.NormalizedValue)
            .IsRequired()
            .HasMaxLength(64);

        builder.HasIndex(x => x.NormalizedValue)
            .IsUnique();

        builder.Property(x => x.VerificationStatus)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(x => x.VerificationMethod)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(x => x.Source)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(x => x.ExternalReference)
            .HasMaxLength(128);

        builder.Property(x => x.IsPrimary)
            .IsRequired();

        builder.Property(x => x.IsSuspended)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.HasOne(x => x.User)
            .WithMany(x => x.Usernames)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}