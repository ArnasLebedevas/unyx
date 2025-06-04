using Unyx.Application.Abstractions.CQRS;
using Unyx.Application.Common.DTOs;

namespace Unyx.Application.Features.Auth.SignUp;

public sealed record SignUpCommand(string Email, string Password) : ICommand<AuthResponseDto>;