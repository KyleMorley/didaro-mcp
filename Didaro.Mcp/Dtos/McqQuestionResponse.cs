namespace Didaro.Mcp.Dtos;

public sealed record McqQuestionResponse(
    string Question,
    IReadOnlyList<string> Options,
    int CorrectIndex,
    string Explanation,
    string? Evidence);