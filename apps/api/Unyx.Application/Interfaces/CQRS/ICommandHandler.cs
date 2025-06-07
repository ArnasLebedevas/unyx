using MediatR;
using Unyx.Application.Common;

namespace Unyx.Application.Interfaces.CQRS;

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>> where TCommand : ICommand<TResponse> {}
