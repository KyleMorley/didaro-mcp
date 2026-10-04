using System.Net.Http.Headers;
using System.Net.Http.Json;
using Didaro.Mcp.Dtos;
using Didaro.Mcp.Interfaces;

namespace Didaro.Mcp.Services;

public sealed class LearningMaterialService(
    IDidaroApiClient didaroApiClient)
    : ILearningMaterialService
{
    /// <summary>
    /// The endpoint for learning material-related API requests.
    /// </summary>
    private const string Endpoint = "learning-materials";

    /// <summary>
    /// The maximum allowed file size for learning material files, in bytes.
    /// </summary>
    private const long MaxFileSizeBytes =
        5 * 1024 * 1024;

    /// <inheritdoc />
    public async Task<LearningMaterialCreateResponse> CreateAsync(
        string name,
        string? description,
        string? text,
        LearningMaterialFile? file,
        Guid? folderId,
        CancellationToken cancellationToken = default)
    {
        using var content =
            new MultipartFormDataContent();

        content.Add(
            new StringContent(name),
            "Name");

        if (!string.IsNullOrWhiteSpace(description))
        {
            content.Add(
                new StringContent(description),
                "Description");
        }

        if (!string.IsNullOrWhiteSpace(text))
        {
            content.Add(
                new StringContent(text),
                "Text");
        }

        if (folderId.HasValue)
        {
            content.Add(
                new StringContent(folderId.Value.ToString()),
                "FolderId");
        }

        if (file is not null)
        {
            AddFile(
                content,
                file);
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

    /// <summary>
    /// Adds a learning material file to the multipart form data content.
    /// </summary>
    /// <param name="content">The multipart form data content to which the file will be added.</param>
    /// <param name="file">The learning material file to add.</param>
    /// <exception cref="ArgumentException"></exception>
    private static void AddFile(
        MultipartFormDataContent content,
        LearningMaterialFile file)
    {
        byte[] bytes;

        try
        {
            bytes =
                Convert.FromBase64String(
                    file.Base64Content);
        }
        catch (FormatException exception)
        {
            throw new ArgumentException(
                "The learning material file is not valid base64.",
                nameof(file),
                exception);
        }

        if (bytes.LongLength > MaxFileSizeBytes)
        {
            throw new ArgumentException(
                "The learning material file cannot exceed 5 MB.",
                nameof(file));
        }

        var fileContent =
            new ByteArrayContent(bytes);

        fileContent.Headers.ContentType =
            MediaTypeHeaderValue.Parse(
                file.ContentType);

        content.Add(
            fileContent,
            "File",
            file.Name);
    }
}