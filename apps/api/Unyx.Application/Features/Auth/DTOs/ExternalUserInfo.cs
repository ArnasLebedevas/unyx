namespace Unyx.Application.Features.Auth.DTOs;

public record ExternalUserInfo(string Email, string FirstName, string LastName, string ProviderUserId);