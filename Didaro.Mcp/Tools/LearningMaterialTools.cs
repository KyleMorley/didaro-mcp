using System.ComponentModel;
using Didaro.Mcp.Dtos;
using Didaro.Mcp.Interfaces;
using ModelContextProtocol.Server;

namespace Didaro.Mcp.Tools;

[McpServerToolType]
public sealed class LearningMaterialTools(
    ILearningMaterialService learningMaterialService)
{
    [McpServerTool]
    [Description(
    "Creates a Didaro learning material from text content.")]
    public async Task<LearningMaterialCreateResponse> CreateLearningMaterialAsync(
    [Description(
        "The name of the learning material.")]
    string name,
    [Description(
        "The text content to save as learning material.")]
    string text,
    [Description(
        "The ID of the Didaro workspace to save the learning material in. Use get_folders to find the workspace ID when needed.")]
    Guid folderId,
    [Description(
        "An optional description of the learning material. Omit when no description is needed.")]
    string description = "",
    CancellationToken cancellationToken = default)
    {
        return await learningMaterialService.CreateAsync(
            name,
            string.IsNullOrWhiteSpace(description)
                ? null
                : description,
            text,
            folderId,
            cancellationToken);
    }
}