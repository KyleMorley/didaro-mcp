using System.ComponentModel;
using Didaro.Mcp.Dtos;
using Didaro.Mcp.Interfaces;
using ModelContextProtocol.Server;

namespace Didaro.Mcp.Tools;

[McpServerToolType]
public sealed class FolderTools(
    IFolderService folderService)
{
    [McpServerTool]
    [Description(
        "Gets the Didaro workspaces available to the current user.")]
    public async Task<IReadOnlyList<FolderResponse>> GetFoldersAsync(
        CancellationToken cancellationToken = default)
    {
        return await folderService.GetFoldersAsync(
            cancellationToken);
    }

    [McpServerTool]
    [Description(
    "Creates a new Didaro workspace for the current user.")]
    public async Task<FolderResponse> CreateFolderAsync(
    [Description("The name of the workspace.")]
    string name,
    [Description(
        "An optional description of the workspace. Omit when no description is needed.")]
    string description = "",
    CancellationToken cancellationToken = default)
    {
        var request = new CreateFolderRequest
        {
            Name = name,
            Description = string.IsNullOrWhiteSpace(description)
                ? null
                : description
        };

        return await folderService.CreateFolderAsync(
            request,
            cancellationToken);
    }
}