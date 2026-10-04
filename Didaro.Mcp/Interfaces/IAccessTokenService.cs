namespace Didaro.Mcp.Interfaces;

public interface IAccessTokenService
{
    /// <summary>
    /// Gets the current access token.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>The current access token as a <see cref="string"/>.</returns>
    Task<string> GetCurrentAsync(CancellationToken cancellationToken = default);
}