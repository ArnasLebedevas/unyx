using MediatR;
using Unyx.Application.Common;

namespace Unyx.Application.Interfaces.CQRS;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>> where TQuery : IQuery<TResponse> {}