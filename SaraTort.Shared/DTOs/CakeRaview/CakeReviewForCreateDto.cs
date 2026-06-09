using System.ComponentModel.DataAnnotations;

namespace SaraTort.BLL.DTOs.CakeReview;

public class CakeReviewForCreateDto
{
    public long CakeId { get; set; }
    public string CustomerName { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
}