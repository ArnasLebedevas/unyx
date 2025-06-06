namespace Unyx.Application.Features.Auth.DTOs;

public class AuthResponseDto
{
    public Guid Id { get; set; }
    public required string Token { get; set; }
    public required string RefreshToken { get; set; }
}