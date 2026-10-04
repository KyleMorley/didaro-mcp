using System.Text.Json.Serialization;

namespace Didaro.Mcp.Dtos;

public sealed class TokenExchangeResponse
{
    [JsonPropertyName("access_token")]
    public required string AccessToken { get; init; }
}