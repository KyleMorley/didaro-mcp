namespace Didaro.Mcp.Dtos;

public sealed record PerformanceLevelResponse(
    string LevelName,
    string Description,
    string? ScoreRange);