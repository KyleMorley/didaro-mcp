using System.ComponentModel.DataAnnotations;

namespace Didaro.Mcp.Dtos;

public sealed class GeneratePracticeExamRequest
{
    [Required]
    [MinLength(20)]
    public string Text { get; init; } = null!;

    public bool RestrictToText { get; init; } = true;

    [Range(3, 10)]
    public int NumQuestions { get; init; } = 5;
}