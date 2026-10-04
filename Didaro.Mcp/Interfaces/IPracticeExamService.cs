using Didaro.Mcp.Dtos;

namespace Didaro.Mcp.Interfaces;

public interface IPracticeExamService
{
    /// <summary>
    /// Generates a practice exam based on the provided request.
    /// </summary>
    /// <param name="request">The request containing the parameters for generating the practice exam.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the generated practice exam response.</returns>
    Task<PracticeExamResponse> GenerateAsync(
        GeneratePracticeExamRequest request,
        CancellationToken cancellationToken = default);
}