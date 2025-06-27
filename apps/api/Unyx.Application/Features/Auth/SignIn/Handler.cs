using Unyx.Application.Common;
using Unyx.Application.Persistence;
using Unyx.Application.Common.Errors;
using Unyx.Application.Common.Messages;
using Unyx.Application.Features.Auth.DTOs;
using Unyx.Application.Interfaces.CQRS;
using Unyx.Application.Interfaces.Services.Auth;
using Unyx.Application.Interfaces.Services.Auth.Tokens;
using Unyx.Application.Interfaces.Services.Users;

namespace Unyx.Application.Features.Auth.SignIn;

internal sealed class SignInHandler(
    IAuthService authService,
    IUnitOfWork unitOfWork,
    IRefreshTokenService refreshTokenService,
    IUserValidationService userValidationService) : ICommandHandler<SignInCommand, AuthResponseDto>
{
    public async Task<Result<AuthResponseDto>> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var user = await userValidationService.ValidateCredentialsAsync(request.Email, request.Password);
        if (user is null) return AppError.Validation(ErrorMessages.InvalidCredentials);

        var refreshToken = await refreshTokenService.GetRefreshTokenAsync(user.Id);
        if (refreshToken.Id == Guid.Empty) unitOfWork.RefreshTokens.Add(refreshToken);

        await unitOfWork.SaveChangesAsync();

        return authService.CreateAuthResponse(user, refreshToken.Token);
    }
}