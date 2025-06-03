using Microsoft.AspNetCore.Mvc;
using Unyx.Application.Common;
using Unyx.Application.Common.Errors;

namespace Unyx.API.Controllers;

[ApiController]
public abstract class BaseApiController : ControllerBase
{
    protected IActionResult HandleResponse<T>(Result<T> response)
    {
        if (response.Success) return Ok(response);

        return response.ErrorType switch
        {
            ErrorType.Validation => BadRequest(response),
            ErrorType.Unauthorized => Unauthorized(response),
            ErrorType.NotFound => NotFound(response),
            ErrorType.Conflict => Conflict(response),
            ErrorType.Business => BadRequest(response),
            _ => StatusCode(500, response)
        };
    }
}
