using Microsoft.Extensions.Options;
using Unyx.Application.Abstractions.Security;
using Unyx.Application.Abstractions.Services;
using Unyx.Application.Common.Settings;

namespace Unyx.Application.Services;

public class AuthService(IJwtService jwtService, IOptions<JwtSettings> authSettings) : IAuthService
{
}
