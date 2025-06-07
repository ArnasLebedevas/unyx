using Unyx.Application.Features.Auth.DTOs;
using Unyx.Application.Interfaces.CQRS;

namespace Unyx.Application.Features.Auth.ValidateRefreshToken;

public sealed record ValidateRefreshTokenCommand(Guid UserId) : ICommand<AuthResponseDto>;