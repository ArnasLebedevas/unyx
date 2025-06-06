using Unyx.Application.Abstractions.CQRS;
using Unyx.Application.Features.Auth.DTOs;

namespace Unyx.Application.Features.Auth.SignIn;

public sealed record SignInCommand(string Email, string Password) : ICommand<AuthResponseDto>;