using Unyx.Domain.Enums;

namespace Unyx.Domain.Entities;

public class ExternalClaim : BaseEntity
{
    public required string Platform { get; set; }
    public required string ExternalUsername { get; set; }
    public string? PlatformUserId { get; set; }

    public ClaimStatus Status { get; set; }
    public ProofReferenceType ProofReferenceType { get; set; }

    public required string ProofReference { get; set; }

    public string? Note { get; set; }

    public DateTime ClaimedAt { get; set; }
    public DateTime? VerifiedAt { get; set; }

    public Guid UserId { get; set; }
    public required User User { get; set; }
}
