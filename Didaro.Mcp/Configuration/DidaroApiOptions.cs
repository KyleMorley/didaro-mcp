namespace Didaro.Mcp.Configuration;

/// <summary>
/// Configuration options for the Didaro API.
/// </summary>
public sealed class DidaroApiOptions
{
    /// <summary>
    /// The name of the configuration section for the Didaro API options.
    /// </summary>
    public const string SectionName = "DidaroApi";
    
    /// <summary>
    /// The base URL of the Didaro API.
    /// </summary>
    public required string BaseUrl { get; init; }

    /// <summary>
    /// The audience of the Didaro API.
    /// </summary>
    public required string Audience { get; init; }

    /// <summary>
    /// The client ID for accessing the Didaro API.
    /// </summary>
    public required string ClientId { get; init; }

    /// <summary>
    /// The client secret for accessing the Didaro API.
    /// </summary>
    public required string ClientSecret { get; init; }
}