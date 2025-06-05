using Unyx.Application.Common.Messages;

namespace Unyx.Application.Common.Exceptions;

public class RefreshTokenNotFoundException(Guid userId) : NotFoundException(string.Format(ErrorMessages.MissingRefreshTokenForUser, userId)) {}