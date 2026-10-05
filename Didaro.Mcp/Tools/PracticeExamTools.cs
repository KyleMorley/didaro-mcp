using System.ComponentModel;
using Didaro.Mcp.Dtos;
using Didaro.Mcp.Interfaces;
using ModelContextProtocol.Server;

namespace Didaro.Mcp.Tools;

[McpServerToolType]
public sealed class PracticeExamTools(
    IPracticeExamService practiceExamService)
{
    [McpServerTool(
    ReadOnly = false,
    Destructive = false,
    OpenWorld = false)]
    [Description(
    "Generates a multiple-choice practice exam from supplied learning content.")]
    public async Task<PracticeExamResponse> GeneratePracticeExamAsync(
        [Description(
            "The learning content to generate the practice exam from.")]
        string text,
        [Description(
            "The number of questions to generate, between 3 and 10.")]
        int numQuestions = 5,
        [Description(
            "Whether the exam must be restricted to information contained in the supplied text.")]
        bool restrictToText = true,
        CancellationToken cancellationToken = default)
    {
        var request = new GeneratePracticeExamRequest
        {
            Text = text,
            NumQuestions = numQuestions,
            RestrictToText = restrictToText
        };

        return await practiceExamService.GenerateAsync(
            request,
            cancellationToken);
    }
}