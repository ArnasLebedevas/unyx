using Unyx.Domain.Enums;

namespace Unyx.Domain.Entities;

public class User : BaseEntity
{
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }

    public string? PhoneNumber { get; set; }
    public bool IsPhoneVerified { get; set; }

    public AuthProvider AuthProvider { get; set; }
    public string? AuthProviderId { get; set; }

    public string? AvatarUrl { get; set; }

    public SubscriptionPlan SubscriptionPlan { get; set; }
    public VerificationStatus VerificationStatus { get; set; }

    public bool IsEmailVerified { get; set; }
    public string? VerificationCode { get; set; }
    public DateTime? CodeExpiry { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? VerifiedAt { get; set; }
    public DateTime? LastLoginAt { get; set; }

    public bool IsDeleted { get; set; } = false;
    public bool IsBanned { get; set; } = false;

    public List<Username> Usernames { get; set; } = [];
    public List<ExternalClaim> LinkedAccounts { get; set; } = [];

    public Guid RoleId { get; set; }
    public required Role Role { get; set; }
}