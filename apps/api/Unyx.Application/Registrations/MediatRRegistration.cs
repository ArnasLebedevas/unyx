using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Unyx.Application.Behaviors;
using Unyx.Application.Features.Auth.SignIn;

namespace Unyx.Application.Registrations;

public static class MediatRRegistration
{
    public static IServiceCollection AddMediatRServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(SignInCommand).Assembly));
        services.AddValidatorsFromAssemblyContaining<SignInValidator>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}