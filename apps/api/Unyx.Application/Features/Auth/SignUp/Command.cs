using Unyx.Application.Features.Auth.DTOs;
using Unyx.Application.Interfaces.CQRS;

namespace Unyx.Application.Features.Auth.SignUp;

public sealed record SignUpCommand(string Email, string Password) : ICommand<AuthResponseDto>;