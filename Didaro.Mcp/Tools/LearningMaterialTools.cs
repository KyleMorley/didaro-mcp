using System.ComponentModel;
using Didaro.Mcp.Dtos;
using Didaro.Mcp.Interfaces;
using ModelContextProtocol.Server;

namespace Didaro.Mcp.Tools;

[McpServerToolType]
public sealed class LearningMaterialTools(
    ILearningMaterialService learningMaterialService)
{
    [McpServerTool(
    ReadOnly = false,
    Destructive = false,
    OpenWorld = false)]
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
            "The ID of the Didaro workspace. Use get_folders to find the workspace ID when needed.")]
        Guid folderId,
        [Description(
            "An optional description. Omit when no description is needed.")]
        string description = "",
        CancellationToken cancellationToken = default)
    {
        return await learningMaterialService.CreateAsync(
            name,
            string.IsNullOrWhiteSpace(description)
                ? null
                : description,
            text,
            null,
            folderId,
            cancellationToken);
    }

    [McpServerTool(
    ReadOnly = false,
    Destructive = false,
    OpenWorld = false)]
    [Description(
        "Creates a Didaro learning material from a PDF file.")]
    public async Task<LearningMaterialCreateResponse> CreateLearningMaterialFromPdfAsync(
        [Description(
            "The name of the learning material.")]
        string name,
        [Description(
            "The ID of the Didaro workspace. Use get_folders to find the workspace ID when needed.")]
        Guid folderId,
        [Description(
            "The PDF file name, including the .pdf extension.")]
        string fileName,
        [Description(
            "The base64-encoded contents of the PDF file.")]
        string base64Content,
        [Description(
            "An optional description. Omit when no description is needed.")]
        string description = "",
        CancellationToken cancellationToken = default)
    {
        var file =
            new LearningMaterialFile(
                fileName,
                "application/pdf",
                base64Content);

        return await learningMaterialService.CreateAsync(
            name,
            string.IsNullOrWhiteSpace(description)
                ? null
                : description,
            null,
            file,
            folderId,
            cancellationToken);
    }
}