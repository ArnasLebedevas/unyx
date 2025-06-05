using Unyx.Application.Common.Errors;

namespace Unyx.Application.Common;

public class Result<T>(bool success, T? data, AppError? error, ErrorType errorType, Dictionary<string, string[]>? validationErrors)
{
    public bool Success { get; } = success;
    public T? Data { get; } = data;
    public AppError? Error { get; } = error;
    public ErrorType ErrorType { get; } = errorType;
    public Dictionary<string, string[]>? ValidationErrors { get; } = validationErrors;

    public static Result<T> SuccessResult(T data) =>
        new(true, data, null, ErrorType.None, null);

    public static Result<T> FailureResult(AppError error, ErrorType errorType = ErrorType.Business, Dictionary<string, string[]>? validationErrors = null) =>
        new(false, default, error, errorType, validationErrors);

    public static implicit operator Result<T>(T data) => SuccessResult(data);

    public static implicit operator Result<T>(AppError error) => FailureResult(error);
}
