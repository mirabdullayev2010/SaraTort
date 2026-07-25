using System.ComponentModel.DataAnnotations;

namespace SaraTort.BLL.DTOs.Cake;

public class CakeForUpdateDto
{
    public string Image { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public long CategoryId { get; set; }
}