using Unyx.Domain.Enums;

namespace Unyx.Domain.Entities;

public class User : BaseEntity
{
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }

    public AuthProvider AuthProvider { get; set; }
    public string? AuthProviderId { get; set; }

    public string? AvatarUrl { get; set; }

    public Subscription Subscription { get; set; }

    public bool IsEmailVerified { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? VerifiedAt { get; set; }
    public DateTime? LastLoginAt { get; set; }

    public bool IsDeleted { get; set; }
    public bool IsBanned { get; set; }

    public List<Username> Usernames { get; set; } = [];
    public List<ExternalClaim> LinkedAccounts { get; set; } = [];

    public Guid RoleId { get; set; }
    public required Role Role { get; set; }
}