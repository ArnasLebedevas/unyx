using MediatR;
using Microsoft.AspNetCore.Mvc;
using Unyx.Application.Features.Auth.GoogleSignIn;
using Unyx.Application.Features.Auth.SignIn;
using Unyx.Application.Features.Auth.SignUp;
using Unyx.Application.Features.Auth.ValidateRefreshToken;

namespace Unyx.API.Controllers;

[Route("api/auth")]
public class AuthController(IMediator mediator) : BaseApiController
{
    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp([FromBody] SignUpCommand command) => HandleResponse(await mediator.Send(command));

    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn([FromBody] SignInCommand command) => HandleResponse(await mediator.Send(command));

    [HttpPost("google-sign-in")]
    public async Task<IActionResult> GoogleSignIn([FromBody] GoogleSignInCommand command) => HandleResponse(await mediator.Send(command));

    [HttpPost("refresh-token")]
    public async Task<IActionResult> ValidateRefreshToken([FromBody] ValidateRefreshTokenCommand command) => HandleResponse(await mediator.Send(command));
}