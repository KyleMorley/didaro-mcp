namespace Didaro.Mcp.Dtos;

public sealed record LearningMaterialCreateResponse(
    Guid Id,
    string Name,
    string? Description,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt);