using System.ComponentModel.DataAnnotations;

namespace SaraTort.BLL.DTOs.Category;

public class CategoryForUpdateDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}