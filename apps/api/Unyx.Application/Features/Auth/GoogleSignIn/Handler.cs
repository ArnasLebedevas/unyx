using Unyx.Application.Common;
using Unyx.Application.Features.Auth.DTOs;
using Unyx.Application.Interfaces.CQRS;

namespace Unyx.Application.Features.Auth.GoogleSignIn;

internal sealed class GoogleSignInHandler : ICommandHandler<GoogleSignInCommand, AuthResponseDto>
{
    public Task<Result<AuthResponseDto>> Handle(GoogleSignInCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
