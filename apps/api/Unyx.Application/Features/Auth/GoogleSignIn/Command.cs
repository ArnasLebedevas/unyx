using Unyx.Application.Features.Auth.DTOs;
using Unyx.Application.Interfaces.CQRS;

namespace Unyx.Application.Features.Auth.GoogleSignIn;

public sealed record GoogleSignInCommand(string Token) : ICommand<AuthResponseDto>;