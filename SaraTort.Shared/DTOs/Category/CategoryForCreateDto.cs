using System.ComponentModel.DataAnnotations;

namespace SaraTort.BLL.DTOs.Category;

public class CategoryForCreateDto
{
    [Required(ErrorMessage = "Kategoriya nomi majburiy kiritilishi kerak!")]
    [StringLength(100, ErrorMessage = "Kategoriya nomi 100 ta belgidan oshmasligi kerak.")]
    public string Name { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "Tavsif 500 ta belgidan oshmasligi kerak.")]
    public string? Description { get; set; }
}