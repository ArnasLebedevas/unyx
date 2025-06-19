using FluentValidation;
using Unyx.Application.Common.Messages;

namespace Unyx.Application.Features.Auth.SignIn;

internal class SignInValidator : AbstractValidator<SignInCommand>
{
    public SignInValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(ValidationMessages.EmailRequired)
            .EmailAddress().WithMessage(ValidationMessages.EmailInvalidFormat);

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(ValidationMessages.PasswordRequired)
            .MinimumLength(8).WithMessage(ValidationMessages.PasswordLength);
    }
}