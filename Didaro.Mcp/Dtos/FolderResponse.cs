namespace Didaro.Mcp.Dtos;

public sealed record FolderResponse(
    Guid Id,
    string Name,
    string? Description,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt);