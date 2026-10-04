using System.ComponentModel;
using Didaro.Mcp.Interfaces;
using ModelContextProtocol.Server;

namespace Didaro.Mcp.Tools;

[McpServerToolType]
public sealed class TestDidaroApiTool(
    IDidaroApiClient didaroApiClient)
{
    [McpServerTool]
    [Description("Tests authenticated access to the Didaro API.")]
    public async Task<string> TestDidaroApiAsync(
        CancellationToken cancellationToken = default)
    {
        using var request =
            new HttpRequestMessage(
                HttpMethod.Get,
                "users/me");

        using HttpResponseMessage response =
            await didaroApiClient.SendAsync(
                request,
                cancellationToken);

        string content =
            await response.Content.ReadAsStringAsync(
                cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException(
                $"Didaro API returned {(int)response.StatusCode}: {content}");
        }

        return content;
    }
}