using Didaro.Mcp.Dtos;

namespace Didaro.Mcp.Interfaces;

public interface IRubricService
{
    /// <summary>
    /// Retrieves all rubrics within the specified folder.
    /// </summary>
    /// <param name="folderId">The ID of the folder containing the rubrics.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the list of rubrics within the specified folder.</returns>
    Task<IReadOnlyList<RubricListItemResponse>> GetAllAsync(
        Guid folderId,
        CancellationToken cancellationToken = default);
        
    /// <summary>
    /// Creates a new rubric based on the provided request.
    /// </summary>
    /// <param name="request">The request containing the details of the rubric to be created.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the created rubric response.</returns>
    Task<SavedRubricResponse> CreateAsync(
        CreateRubricRequest request,
        CancellationToken cancellationToken = default);
}