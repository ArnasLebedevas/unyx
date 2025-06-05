using Unyx.Application.Common.Errors;
using Unyx.Application.Common.Exceptions;
using Unyx.Application.Common;

namespace Unyx.API.Middlewares;

public static class ExceptionMapper
{
    public static (int StatusCode, Result<object> Result) Map(Exception exception)
    {
        return exception switch
        {
            ValidationException valEx => (
                StatusCodes.Status400BadRequest,
                Result<object>.FailureResult(
                    AppError.Validation(valEx.Message),
                    ErrorType.Validation,
                    valEx.Errors?.ToDictionary(error => error.Key, error => error.Value)
                )
            ),
            UnauthorizedAccessException => (
                StatusCodes.Status401Unauthorized,
                Result<object>.FailureResult(AppError.Unauthorized, ErrorType.Unauthorized)
            ),
            NotFoundException notFoundEx => (
                StatusCodes.Status404NotFound,
                Result<object>.FailureResult(AppError.NotFound(notFoundEx.Message), ErrorType.NotFound)
            ),
            _ => (
                StatusCodes.Status500InternalServerError,
                Result<object>.FailureResult(AppError.System, ErrorType.System)
            )
        };
    }
}