using System.ComponentModel.DataAnnotations;

namespace Didaro.Mcp.Dtos;

public sealed class CreateRubricRequest
{
    [MaxLength(200)]
    public string? Name { get; init; }

    [MaxLength(250)]
    public string? Description { get; init; }

    public Guid? FolderId { get; init; }

    [Required]
    public required RubricResponse Rubric { get; init; }
}