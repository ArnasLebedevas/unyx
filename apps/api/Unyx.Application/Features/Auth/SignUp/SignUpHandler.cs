using Unyx.Application.Abstractions.CQRS;
using Unyx.Application.Abstractions.Security;
using Unyx.Application.Abstractions.Services;
using Unyx.Application.Common.DTOs;
using Unyx.Application.Common.Messages;
using Unyx.Application.Common;
using Unyx.Application.Persistence.Read;
using Unyx.Application.Persistence;
using Unyx.Application.Common.Errors;

namespace Unyx.Application.Features.Auth.SignUp;

internal sealed class SignUpHandler(
    IUserReadRepository userReadRepository,
    IUnitOfWork unitOfWork,
    IAuthService authService,
    IUserService userService,
    IRefreshTokenService refreshTokenService) : ICommandHandler<SignUpCommand, AuthResponseDto>
{
    public async Task<Result<AuthResponseDto>> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        var user = await userReadRepository.GetUserByEmailAsync(request.Email);
        if (user is not null) return AppError.Validation(ErrorMessages.InvalidCredentials);

        var newUser = userService.CreateUser(new CreateUserDto(request.Email, request.Password));

        var refreshToken = await refreshTokenService.GetRefreshTokenAsync(newUser.Id);
        if (refreshToken.Id == Guid.Empty) unitOfWork.RefreshTokens.Add(refreshToken);

        await unitOfWork.SaveChangesAsync();

        return authService.CreateAuthResponse(newUser, refreshToken.Token);
    }
}