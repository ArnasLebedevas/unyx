using FluentValidation.Results;
using Unyx.Application.Common.Messages;

namespace Unyx.Application.Common.Exceptions;

public class ValidationException(IEnumerable<ValidationFailure> failures) : Exception(ErrorMessages.ValidationFailed)
{
    public IDictionary<string, string[]> Errors { get; } = failures
        .GroupBy(error => error.PropertyName)
        .ToDictionary(group => group.Key, group => group.Select(fail => fail.ErrorMessage).ToArray());
}
