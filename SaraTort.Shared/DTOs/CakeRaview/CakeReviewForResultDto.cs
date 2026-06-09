namespace SaraTort.BLL.DTOs.CakeReview;

public class CakeReviewForResultDto
{
    public long Id { get; set; }
    public long CakeId { get; set; }
    public string CustomerName { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }

    public DateTime CreatedAt { get; set; }
}