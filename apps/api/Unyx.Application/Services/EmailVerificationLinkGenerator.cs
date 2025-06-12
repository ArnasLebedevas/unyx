using Microsoft.Extensions.Options;
using System.Web;
using Unyx.Application.Common.Settings;
using Unyx.Application.Interfaces.Security;
using Unyx.Application.Interfaces.Services;
using Unyx.Domain.Entities;

namespace Unyx.Application.Services;

internal class EmailVerificationLinkGenerator(IAuthTokenService tokenService, IOptions<FrontendSettings> settings) : IEmailVerificationLinkGenerator
{
    private readonly string _frontendBaseUrl = settings.Value.BaseUrl;

    public string GenerateLink(User user)
    {
        var token = tokenService.GenerateToken(user);

        var uriBuilder = new UriBuilder(_frontendBaseUrl)
        {
            Path = "verify-email",
            Query = $"token={HttpUtility.UrlEncode(token)}"
        };

        return uriBuilder.ToString();
    }
}
