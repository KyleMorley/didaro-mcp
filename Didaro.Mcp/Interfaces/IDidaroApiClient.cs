namespace Didaro.Mcp.Interfaces;

public interface IDidaroApiClient
{
    /// <summary>
    /// Sends an HTTP GET request to the specified endpoint and returns the response deserialized as the specified type.
    /// </summary>
    /// <typeparam name="TResponse">The type to deserialize the response into.</typeparam>
    /// <param name="endpoint">The endpoint to send the GET request to.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The response deserialized as the specified type.</returns>
    Task<TResponse> GetAsync<TResponse>(
        string endpoint,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends an HTTP POST request to the specified endpoint with the given request body and returns the response deserialized as the specified type.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request body.</typeparam>
    /// <typeparam name="TResponse">The type to deserialize the response into.</typeparam>
    /// <param name="endpoint">The endpoint to send the POST request to.</param>
    /// <param name="request">The request body to send.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The response deserialized as the specified type.</returns> 
    Task<TResponse> PostAsync<TRequest, TResponse>(
        string endpoint,
        TRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends an HTTP request and returns the raw HTTP response.
    /// </summary>
    /// <param name="request">The HTTP request message to send.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The raw HTTP response message.</returns>
    Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken = default);
}