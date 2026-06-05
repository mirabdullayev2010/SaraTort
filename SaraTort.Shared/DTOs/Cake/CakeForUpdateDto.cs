using System.ComponentModel.DataAnnotations;

namespace SaraTort.BLL.DTOs.Cake;

public class CakeForUpdateDto
{
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Tort nomi majburiy!")]
    [StringLength(100, ErrorMessage = "Tort nomi 100 ta belgidan oshmasligi kerak.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Tort tavsifi majburiy!")]
    [StringLength(1000, ErrorMessage = "Tavsif 1000 ta belgidan oshmasligi kerak.")]
    public string Description { get; set; } = string.Empty;

    public string? ImageUrl { get; set; }

    [Required(ErrorMessage = "Kategoriya tanlanishi shart!")]
    public int CategoryId { get; set; }
}