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
            await accessTokenService.GetCurrentAsync(cancellationToken);

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

    /// <inheritdoc />
    public async Task<TResponse> GetAsync<TResponse>(
        string endpoint,
        CancellationToken cancellationToken = default)
    {
        using var request =
            new HttpRequestMessage(
                HttpMethod.Get,
                endpoint);

        using HttpResponseMessage response =
            await SendAsync(
                request,
                cancellationToken);

        response.EnsureSuccessStatusCode();

        TResponse? result =
            await response.Content.ReadFromJsonAsync<TResponse>(
                cancellationToken);

        return result
            ?? throw new InvalidOperationException(
                "Didaro API returned an empty response.");
    }

    /// <inheritdoc />
    public async Task<TResponse> PostAsync<TRequest, TResponse>(
        string endpoint,
        TRequest request,
        CancellationToken cancellationToken = default)
    {
        using var message =
            new HttpRequestMessage(
                HttpMethod.Post,
                endpoint)
            {
                Content = JsonContent.Create(request)
            };

        using HttpResponseMessage response =
            await SendAsync(
                message,
                cancellationToken);

        response.EnsureSuccessStatusCode();

        TResponse? result =
            await response.Content.ReadFromJsonAsync<TResponse>(
                cancellationToken);

        return result
            ?? throw new InvalidOperationException(
                "Didaro API returned an empty response.");
    }
}