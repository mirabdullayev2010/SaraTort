namespace SaraTort.BLL.DTOs.CakeReview;

public class CakeReviewForResultDto
{
    public int Id { get; set; }
    public int CakeId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
    public int Rating { get; set; }

    public DateTime CreatedAt { get; set; }
}