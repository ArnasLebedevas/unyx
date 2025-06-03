using MediatR;
using Unyx.Application.Common;

namespace Unyx.Application.Abstractions.CQRS;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> {}