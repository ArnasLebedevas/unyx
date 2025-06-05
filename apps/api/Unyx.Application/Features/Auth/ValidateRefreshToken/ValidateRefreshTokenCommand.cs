using Unyx.Application.Abstractions.CQRS;
using Unyx.Application.Common.DTOs;

namespace Unyx.Application.Features.Auth.ValidateRefreshToken;

public sealed record ValidateRefreshTokenCommand(Guid UserId) : ICommand<AuthResponseDto>;