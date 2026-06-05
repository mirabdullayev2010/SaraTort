using System.ComponentModel.DataAnnotations;

namespace SaraTort.BLL.DTOs.CakeReview;

public class CakeReviewForCreateDto
{
    [Required]
    public int CakeId { get; set; }

    [Required(ErrorMessage = "Ismingizni kiritishingiz shart!")]
    [StringLength(50, ErrorMessage = "Ism 50 ta belgidan oshmasligi kerak.")]
    public string CustomerName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Fikringizni qoldirishingiz shart!")]
    [StringLength(500, ErrorMessage = "Izoh 500 ta belgidan oshmasligi kerak.")]
    public string Comment { get; set; } = string.Empty;

    [Required(ErrorMessage = "Baholash majburiy!")]
    [Range(1, 5, ErrorMessage = "Baho 1 dan 5 gacha bo'lishi shart.")]
    public int Rating { get; set; }
}