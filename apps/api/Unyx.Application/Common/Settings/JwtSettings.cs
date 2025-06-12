namespace Unyx.Application.Common.Settings;

public class JwtSettings
{
    public required string Secret { get; set; }
    public int TokenExpiryMinutes { get; set; }
    public int RefreshTokenExpiryDays { get; set; }
    public int EmailVerificationTokenExpiryMinutes { get; set; }
    public required string Issuer { get; set; }
    public required string Audience { get; set; }
}