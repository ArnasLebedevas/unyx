using Unyx.Application.Abstractions.CQRS;
using Unyx.Application.Abstractions.Security;
using Unyx.Application.Abstractions.Services;
using Unyx.Application.Common;
using Unyx.Application.Persistence;
using Unyx.Application.Persistence.Read;
using Unyx.Application.Common.Errors;
using Unyx.Application.Features.Auth.DTOs;

namespace Unyx.Application.Features.Auth.ValidateRefreshToken;

internal sealed class ValidateRefreshTokenHandler(IRefreshTokenService refreshTokenService, IUserReadRepository userReadRepository, IUnitOfWork unitOfWork, IAuthService authService) : ICommandHandler<ValidateRefreshTokenCommand, AuthResponseDto>
{
    public async Task<Result<AuthResponseDto>> Handle(ValidateRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var user = await userReadRepository.GetByIdAsync(request.UserId);
        if (user is null) return AppError.NotFound(nameof(user));

        var refreshToken = await refreshTokenService.GetRefreshTokenAsync(request.UserId);
        if (refreshToken.Id == Guid.Empty) unitOfWork.RefreshTokens.Add(refreshToken);

        await unitOfWork.SaveChangesAsync();

        return authService.CreateAuthResponse(user, refreshToken.Token);
    }
}