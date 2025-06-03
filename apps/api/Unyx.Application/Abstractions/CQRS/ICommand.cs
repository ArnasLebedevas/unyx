using MediatR;
using Unyx.Application.Common;

namespace Unyx.Application.Abstractions.CQRS;

public interface ICommand<TResponse> : IRequest<Result<TResponse>> {}