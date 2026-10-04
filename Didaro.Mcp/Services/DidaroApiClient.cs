using System.Net.Http.Headers;
using Didaro.Mcp.Configuration;
using Didaro.Mcp.Interfaces;
using Microsoft.Extensions.Options;

namespace Didaro.Mcp.Services;

public sealed class DidaroApiClient(
    IHttpClientFactory httpClientFactory,
    IAccessTokenService accessTokenService,
    ITokenExchangeService tokenExchangeService,
    IOptions<DidaroApiOptions> didaroApiOptions)
    : IDidaroApiClient
{
    /// <summary>
    /// The options for configuring the Didaro API client.
    /// </summary>
    private readonly DidaroApiOptions _didaroApiOptions =
        didaroApiOptions.Value;

    /// <inheritdoc />
    public async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken = default)
    {
        string subjectToken =
            await accessTokenService.GetCurrentAsync();

        string accessToken =
            await tokenExchangeService.ExchangeAsync(
                subjectToken,
                cancellationToken);

        HttpClient httpClient =
            httpClientFactory.CreateClient();

        httpClient.BaseAddress =
            new Uri(_didaroApiOptions.BaseUrl);

        request.Headers.Authorization =
            new AuthenticationHeaderValue(
                "Bearer",
                accessToken);

        return await httpClient.SendAsync(
            request,
            cancellationToken);
    }
}