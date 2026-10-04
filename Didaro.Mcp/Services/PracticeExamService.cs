using Didaro.Mcp.Dtos;
using Didaro.Mcp.Interfaces;

namespace Didaro.Mcp.Services;

public sealed class PracticeExamService(
    IDidaroApiClient didaroApiClient)
    : IPracticeExamService
{
    /// <summary>
    /// The endpoint for generating practice exams.
    /// </summary>
    private const string Endpoint =
        "practice-exams/generate";

    /// <inheritdoc />
    public async Task<PracticeExamResponse> GenerateAsync(
        GeneratePracticeExamRequest request,
        CancellationToken cancellationToken = default)
    {
        return await didaroApiClient
            .PostAsync<
                GeneratePracticeExamRequest,
                PracticeExamResponse>(
                Endpoint,
                request,
                cancellationToken);
    }
}