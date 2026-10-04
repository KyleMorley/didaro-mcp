using Didaro.Mcp.Dtos;

namespace Didaro.Mcp.Interfaces;

public interface ILearningMaterialService
{
    /// <summary>
    /// Creates a new learning material in the specified folder.
    /// </summary>
    /// <param name="name">The name of the learning material.</param>
    /// <param name="description">A brief description of the learning material.</param>
    /// <param name="text">The content of the learning material.</param>
    /// <param name="folderId">The ID of the folder where the learning material will be created.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The response containing details of the created learning material.</returns>
    Task<LearningMaterialCreateResponse> CreateAsync(
        string name,
        string? description,
        string text,
        Guid? folderId,
        CancellationToken cancellationToken = default);
}