using System.ComponentModel.DataAnnotations;

namespace Didaro.Mcp.Dtos;

public sealed class CreateFolderRequest
{
    [Required]
    [MaxLength(200)]
    public string Name { get; init; } = null!;

    [MaxLength(250)]
    public string? Description { get; init; }
}