using Didaro.Mcp.Dtos;
using Didaro.Mcp.Interfaces;

namespace Didaro.Mcp.Services;

public sealed class RubricService(
    IDidaroApiClient didaroApiClient)
    : IRubricService
{
    /// <summary>
    /// The endpoint for rubric-related operations.
    /// </summary>
    private const string Endpoint = "rubrics";

    /// <inheritdoc />
    public async Task<IReadOnlyList<RubricListItemResponse>> GetAllAsync(
        Guid folderId,
        CancellationToken cancellationToken = default)
    {
        string endpoint =
            $"{Endpoint}?folderId={folderId}";

        return await didaroApiClient
            .GetAsync<IReadOnlyList<RubricListItemResponse>>(
                endpoint,
                cancellationToken);
    }

    /// <inheritdoc />
    public async Task<SavedRubricResponse> CreateAsync(
        CreateRubricRequest request,
        CancellationToken cancellationToken = default)
    {
        return await didaroApiClient
            .PostAsync<CreateRubricRequest, SavedRubricResponse>(
                Endpoint,
                request,
                cancellationToken);
    }
}