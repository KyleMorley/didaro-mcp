namespace Didaro.Mcp.Dtos;

public sealed record SavedRubricResponse(
    Guid Id,
    string Name,
    string? Description,
    Guid FolderId,
    RubricResponse Rubric);