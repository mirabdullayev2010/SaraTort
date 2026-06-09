namespace SaraTort.Shared.DTOs.CakeRaview;

public class CakeReviewForShortResultDto
{
    public long Id { get; set; }
    public long CakeId { get; set; }
    public string CustomerName { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }

    public DateTime CreatedAt { get; set; }
}
