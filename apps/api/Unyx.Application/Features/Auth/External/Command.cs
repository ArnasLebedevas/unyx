using Unyx.Application.Features.Auth.DTOs;
using Unyx.Application.Interfaces.CQRS;
using Unyx.Domain.Enums;

namespace Unyx.Application.Features.Auth.External;

public class ExternalSignInCommand : ICommand<AuthResponseDto>
{
    public required AuthProvider Provider { get; set; }
    public required string AccessToken { get; set; }
}