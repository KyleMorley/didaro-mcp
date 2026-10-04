namespace Didaro.Mcp.Dtos;

public sealed record PracticeExamResponse(
    string Title,
    string? Description,
    IReadOnlyList<McqQuestionResponse> Questions,
    bool RestrictToText,
    string? ModelVersion);