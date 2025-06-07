using Unyx.Application.Features.Auth.DTOs;
using Unyx.Application.Interfaces.CQRS;

namespace Unyx.Application.Features.Auth.SignIn;

public sealed record SignInCommand(string Email, string Password) : ICommand<AuthResponseDto>;