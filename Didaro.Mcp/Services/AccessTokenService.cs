using Didaro.Mcp.Interfaces;
using Microsoft.AspNetCore.Authentication;

namespace Didaro.Mcp.Services;

public sealed class AccessTokenService(
    IHttpContextAccessor httpContextAccessor)
    : IAccessTokenService
{
    /// <inheritdoc />
    public async Task<string> GetCurrentAsync(CancellationToken cancellationToken = default)
    {
        HttpContext httpContext =
            httpContextAccessor.HttpContext
            ?? throw new InvalidOperationException(
                "No active HTTP context is available.");

        string? accessToken =
            await httpContext.GetTokenAsync("access_token");

        return !string.IsNullOrWhiteSpace(accessToken)
            ? accessToken
            : throw new InvalidOperationException(
                "The authenticated request does not contain an access token.");
    }
}