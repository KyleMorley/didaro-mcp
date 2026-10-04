namespace Didaro.Mcp.Dtos;

public sealed record RubricCriterionResponse(
    string Name,
    string Description,
    IReadOnlyList<PerformanceLevelResponse> PerformanceLevels);