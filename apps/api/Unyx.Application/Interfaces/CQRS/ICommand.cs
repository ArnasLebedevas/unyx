using MediatR;
using Unyx.Application.Common;

namespace Unyx.Application.Interfaces.CQRS;

public interface ICommand<TResponse> : IRequest<Result<TResponse>> {}