namespace Didaro.Mcp.Interfaces;

public interface IDidaroApiClient
{
    /// <summary>
    /// Sends an HTTP request to the Didaro API and returns the response.
    /// </summary>
    /// <param name="request">The HTTP request message to send to the Didaro API.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>The HTTP response message from the Didaro API.</returns>
    Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken = default);
}