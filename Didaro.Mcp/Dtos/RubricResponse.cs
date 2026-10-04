namespace Didaro.Mcp.Dtos;

public sealed record RubricResponse(
    string RubricTitle,
    string? Description,
    IReadOnlyList<RubricCriterionResponse> Criteria);