using Unyx.Application.Common.Messages;
using Unyx.Application.Common;
using Unyx.Application.Persistence.Read;
using Unyx.Application.Persistence;
using Unyx.Application.Common.Errors;
using Unyx.Application.Features.Auth.DTOs;
using Unyx.Application.Interfaces.CQRS;
using Unyx.Application.Interfaces.Services.Auth;
using Unyx.Application.Interfaces.Services.Users;
using Unyx.Application.Interfaces.Services.Auth.Tokens;

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