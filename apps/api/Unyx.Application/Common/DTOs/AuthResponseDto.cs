namespace Unyx.Application.Common.DTOs;

public class AuthResponseDto
{
    public Guid Id { get; set; }
    public required string Token { get; set; }
}