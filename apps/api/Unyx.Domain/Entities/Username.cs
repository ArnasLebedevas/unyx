using Unyx.Domain.Enums;

namespace Unyx.Domain.Entities;

public class Username : BaseEntity
{
    public required string Value { get; set; }
    public VerificationStatus VerificationStatus { get; set; }

    public bool IsPrimary { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? VerifiedAt { get; set; }

    public Guid UserId { get; set; }
    public required User User { get; set; }
}