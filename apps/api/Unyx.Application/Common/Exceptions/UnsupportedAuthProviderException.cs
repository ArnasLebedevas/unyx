using Unyx.Domain.Enums;

namespace Unyx.Application.Common.Exceptions;

public class UnsupportedAuthProviderException(AuthProvider provider) : Exception($"Authentication provider '{provider}' is not supported.") {}