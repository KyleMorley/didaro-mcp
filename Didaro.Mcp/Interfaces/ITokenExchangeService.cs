namespace Didaro.Mcp.Interfaces;

public interface ITokenExchangeService
{
    /// <summary>
    /// Exchanges the given subject token for an access token.
    /// </summary>
    /// <param name="subjectToken">The subject token to be exchanged.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The access token obtained from the exchange.</returns>
    Task<string> ExchangeAsync(
        string subjectToken,
        CancellationToken cancellationToken = default);
}