using Didaro.Mcp.Configuration;
using Didaro.Mcp.Dtos;
using Didaro.Mcp.Interfaces;
using Microsoft.Extensions.Options;

namespace Didaro.Mcp.Services;

public sealed class TokenExchangeService(
    IHttpClientFactory httpClientFactory,
    IOptions<Auth0Options> auth0Options,
    IOptions<DidaroApiOptions> didaroApiOptions)
    : ITokenExchangeService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TokenExchangeService"/> class.
    /// </summary>
    private readonly Auth0Options _auth0Options =
        auth0Options.Value;

    /// <summary>
    /// Gets the Auth0 options.
    /// </summary>
    private readonly DidaroApiOptions _didaroApiOptions =
        didaroApiOptions.Value;

    /// <inheritdoc/>
    public async Task<string> ExchangeAsync(
    string subjectToken,
    CancellationToken cancellationToken = default)
    {
        HttpClient httpClient =
            httpClientFactory.CreateClient();

        string tokenEndpoint =
            $"https://{_auth0Options.Domain.TrimEnd('/')}/oauth/token";

        var request = new Dictionary<string, string>
        {
            ["client_id"] = _didaroApiOptions.ClientId,
            ["client_secret"] = _didaroApiOptions.ClientSecret,
            ["subject_token"] = subjectToken,
            ["grant_type"] =
                "urn:ietf:params:oauth:grant-type:token-exchange",
            ["subject_token_type"] =
                "urn:ietf:params:oauth:token-type:access_token",
            ["requested_token_type"] =
                "urn:ietf:params:oauth:token-type:access_token",
            ["audience"] = _didaroApiOptions.Audience
        };

        using var content =
            new FormUrlEncodedContent(request);

        using HttpResponseMessage response =
            await httpClient.PostAsync(
                tokenEndpoint,
                content,
                cancellationToken);

        response.EnsureSuccessStatusCode();

        TokenExchangeResponse? tokenResponse =
            await response.Content.ReadFromJsonAsync<TokenExchangeResponse>(
                cancellationToken);

        return tokenResponse?.AccessToken
            ?? throw new InvalidOperationException(
                "Auth0 token exchange did not return an access token.");
    }
}