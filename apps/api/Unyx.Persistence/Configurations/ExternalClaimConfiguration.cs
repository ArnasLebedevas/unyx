using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Unyx.Domain.Entities;
using Unyx.Domain.Enums;

namespace Unyx.Persistence.Configurations;

internal sealed class ExternalClaimConfiguration : IEntityTypeConfiguration<ExternalClaim>
{
    public void Configure(EntityTypeBuilder<ExternalClaim> builder)
    {
        builder.HasKey(ec => ec.Id);

        builder.Property(ec => ec.Platform)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ec => ec.ExternalUsername)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(ec => ec.ProofReference)
            .IsRequired()
            .HasMaxLength(2048);

        builder.Property(ec => ec.UserId)
            .IsRequired();

        builder.Property(ec => ec.PlatformUserId)
            .HasMaxLength(128);

        builder.Property(ec => ec.Note)
            .HasMaxLength(1000);

        builder.Property(ec => ec.Status)
            .HasDefaultValue(ClaimStatus.Pending)
            .HasConversion<string>();

        builder.Property(ec => ec.ProofReferenceType)
            .HasDefaultValue(ProofReferenceType.Url)
            .HasConversion<string>();

        builder.Property(ec => ec.VerifiedBySystem)
            .HasDefaultValue(false);

        builder.Property(ec => ec.ClaimedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(ec => ec.VerifiedAt)
            .IsRequired(false);

        builder.HasOne(ec => ec.User)
            .WithMany(u => u.LinkedAccounts)
            .HasForeignKey(ec => ec.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}