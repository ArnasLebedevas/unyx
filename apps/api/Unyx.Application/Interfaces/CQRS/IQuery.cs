using MediatR;
using Unyx.Application.Common;

namespace Unyx.Application.Interfaces.CQRS;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> {}