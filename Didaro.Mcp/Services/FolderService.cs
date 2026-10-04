using Didaro.Mcp.Dtos;
using Didaro.Mcp.Interfaces;

namespace Didaro.Mcp.Services;

public sealed class FolderService(
    IDidaroApiClient didaroApiClient)
    : IFolderService
{
    /// <summary>
    /// The API endpoint for folder-related operations.
    /// </summary>
    private const string Endpoint = "folders";

    /// <inheritdoc />
    public async Task<IReadOnlyList<FolderResponse>> GetFoldersAsync(
        CancellationToken cancellationToken = default)
    {
        return await didaroApiClient
            .GetAsync<IReadOnlyList<FolderResponse>>(
                Endpoint,
                cancellationToken);
    }

    /// <inheritdoc />
    public async Task<FolderResponse> CreateFolderAsync(
        CreateFolderRequest request,
        CancellationToken cancellationToken = default)
    {
        return await didaroApiClient
            .PostAsync<CreateFolderRequest, FolderResponse>(
                Endpoint,
                request,
                cancellationToken);
    }
}