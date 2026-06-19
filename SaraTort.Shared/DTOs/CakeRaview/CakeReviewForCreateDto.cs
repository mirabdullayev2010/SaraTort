using System.ComponentModel.DataAnnotations;

namespace SaraTort.BLL.DTOs.CakeReview;

public class CakeReviewForCreateDto
{
    [Required]
    public int CakeId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
    public int Rating { get; set; }
}