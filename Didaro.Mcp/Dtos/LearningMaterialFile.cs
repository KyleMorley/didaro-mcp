namespace Didaro.Mcp.Dtos;

public sealed record LearningMaterialFile(
    string Name,
    string ContentType,
    string Base64Content);