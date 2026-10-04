namespace Didaro.Mcp.Dtos;

public sealed record RubricListItemResponse(
    Guid Id,
    string Name,
    string? Description,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt);