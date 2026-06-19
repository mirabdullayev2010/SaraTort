using System.ComponentModel.DataAnnotations;

namespace SaraTort.BLL.DTOs.Cake;

public class CakeForUpdateDto
{
    [Required]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public int CategoryId { get; set; }
}