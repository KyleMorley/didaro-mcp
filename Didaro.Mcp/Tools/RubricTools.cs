using System.ComponentModel;
using Didaro.Mcp.Dtos;
using Didaro.Mcp.Interfaces;
using ModelContextProtocol.Server;

namespace Didaro.Mcp.Tools;

[McpServerToolType]
public sealed class RubricTools(
    IRubricService rubricService)
{
    [McpServerTool(
    ReadOnly = true,
    Destructive = false,
    OpenWorld = false)]
    [Description(
    "Gets the rubrics saved in a Didaro workspace.")]
    public async Task<IReadOnlyList<RubricListItemResponse>> GetRubricsAsync(
        [Description(
            "The ID of the Didaro workspace containing the rubrics.")]
        Guid folderId,
        CancellationToken cancellationToken = default)
    {
        return await rubricService.GetAllAsync(
            folderId,
            cancellationToken);
    }
}