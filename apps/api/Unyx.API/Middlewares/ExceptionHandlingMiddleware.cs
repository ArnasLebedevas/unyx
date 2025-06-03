using Unyx.Application.Common.Errors;
using Unyx.Application.Common;
using System.Text.Json;
using Unyx.Application.Common.Exceptions;

namespace Unyx.API.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    private static readonly JsonSerializerOptions CachedJsonSerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = false
    };

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unhandled exception: {Message}", ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        (int statusCode, AppError error, ErrorType type, Dictionary<string, string[]>? validationErrors) = exception switch
        {
            ValidationException valEx => (
                StatusCodes.Status400BadRequest,
                AppError.Validation(valEx.Message),
                ErrorType.Validation,
                valEx.Errors?.ToDictionary(e => e.Key, e => e.Value)
            ),
            UnauthorizedAccessException => (
                StatusCodes.Status401Unauthorized,
                AppError.Unauthorized,
                ErrorType.Unauthorized,
                null
            ),
            KeyNotFoundException => (
                StatusCodes.Status404NotFound,
                AppError.NotFound("Resource"),
                ErrorType.NotFound,
                null
            ),
            _ => (
                StatusCodes.Status500InternalServerError,
                AppError.System,
                ErrorType.System,
                null
            )
        };

        var result = new Result<object>(
            success: false,
            data: null,
            error: error,
            errorType: type,
            validationErrors: validationErrors
        );

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        var json = JsonSerializer.Serialize(result, CachedJsonSerializerOptions);

        return context.Response.WriteAsync(json);
    }
}
