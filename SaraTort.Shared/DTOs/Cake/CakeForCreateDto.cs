using System.ComponentModel.DataAnnotations;

namespace SaraTort.BLL.DTOs.Cake;

public class CakeForCreateDto
{
    [Required(ErrorMessage = "Tort nomi majburiy kiritilishi kerak!")]
    [StringLength(100, ErrorMessage = "Tort nomi 100 ta belgidan oshmasligi kerak.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Tort haqida tavsif (description) yozish majburiy!")]
    [StringLength(1000, ErrorMessage = "Tavsif 1000 ta belgidan oshmasligi kerak.")]
    public string Description { get; set; }

    public string? ImageUrl { get; set; }

    [Required(ErrorMessage = "Kategoriya tanlanishi shart!")]
    public int CategoryId { get; set; }
}