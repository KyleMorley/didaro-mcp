using Didaro.Mcp.Dtos;
using Didaro.Mcp.Interfaces;

namespace Didaro.Mcp.Services;

public sealed class LearningMaterialService(
    IDidaroApiClient didaroApiClient)
    : ILearningMaterialService
{
    /// <summary>
    /// Service for managing learning materials.
    /// </summary>
    private const string Endpoint = "learning-materials";

    /// <inheritdoc/>
    public async Task<LearningMaterialCreateResponse> CreateAsync(
        string name,
        string? description,
        string text,
        Guid? folderId,
        CancellationToken cancellationToken = default)
    {
        using var content =
            new MultipartFormDataContent();

        content.Add(
            new StringContent(name),
            "Name");

        content.Add(
            new StringContent(text),
            "Text");

        if (!string.IsNullOrWhiteSpace(description))
        {
            content.Add(
                new StringContent(description),
                "Description");
        }

        if (folderId.HasValue)
        {
            content.Add(
                new StringContent(folderId.Value.ToString()),
                "FolderId");
        }

        using var request =
            new HttpRequestMessage(
                HttpMethod.Post,
                Endpoint)
            {
                Content = content
            };

        using HttpResponseMessage response =
            await didaroApiClient.SendAsync(
                request,
                cancellationToken);

        response.EnsureSuccessStatusCode();

        LearningMaterialCreateResponse? result =
            await response.Content
                .ReadFromJsonAsync<LearningMaterialCreateResponse>(
                    cancellationToken);

        return result
            ?? throw new InvalidOperationException(
                "Didaro API returned an empty response.");
    }
}