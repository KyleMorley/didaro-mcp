using Didaro.Mcp.Dtos;
namespace Didaro.Mcp.Interfaces;

public interface IFolderService
{
    /// <summary>
    /// Gets a list of all folders.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A read-only list of folder responses.</returns>
    Task<IReadOnlyList<FolderResponse>> GetFoldersAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new folder.
    /// </summary>
    /// <param name="request">The create folder request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The created folder response.</returns>
    Task<FolderResponse> CreateFolderAsync(
        CreateFolderRequest request,
        CancellationToken cancellationToken = default);
}