using Unyx.Application.Abstractions.CQRS;
using Unyx.Application.Abstractions.Services;
using Unyx.Application.Common.DTOs;
using Unyx.Application.Common;
using Unyx.Application.Persistence;
using Unyx.Application.Common.Errors;
using Unyx.Application.Abstractions.Security;
using Unyx.Application.Common.Messages;

namespace Unyx.Application.Features.Auth.SignIn;

internal sealed class SignInHandler(IAuthService authService, IUnitOfWork unitOfWork, IRefreshTokenService refreshTokenService) : ICommandHandler<SignInCommand, AuthResponseDto>
{
    public async Task<Result<AuthResponseDto>> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var user = await authService.ValidateUserCredentialsAsync(request.Email, request.Password);
        if (user is null) return AppError.Validation(ErrorMessages.InvalidCredentials);

        var refreshToken = await refreshTokenService.GetRefreshTokenAsync(user.Id);
        if (refreshToken.Id == Guid.Empty) unitOfWork.RefreshTokens.Add(refreshToken);

        await unitOfWork.SaveChangesAsync();

        return authService.CreateAuthResponse(user, refreshToken.Token);
    }
}