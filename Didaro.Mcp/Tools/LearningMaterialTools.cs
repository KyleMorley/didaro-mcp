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
            "The ID of the Didaro workspace to save the learning material in.")]
        Guid? folderId = null,
        [Description(
            "An optional description of the learning material.")]
        string? description = null,
        CancellationToken cancellationToken = default)
    {
        return await learningMaterialService.CreateAsync(
            name,
            description,
            text,
            folderId,
            cancellationToken);
    }
}