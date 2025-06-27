namespace Unyx.Application.Features.Auth.DTOs;

public record AuthResponseDto(Guid Id, string Token, string RefreshToken);