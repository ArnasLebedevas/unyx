using MediatR;
using Microsoft.AspNetCore.Mvc;
using Unyx.Application.Features.Auth.SignIn;
using Unyx.Application.Features.Auth.SignUp;

namespace Unyx.API.Controllers;

[Route("api/auth")]
public class AuthController(IMediator mediator) : BaseApiController
{
    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp([FromBody] SignUpCommand command) => HandleResponse(await mediator.Send(command));

    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn([FromBody] SignInCommand command) => HandleResponse(await mediator.Send(command));
}