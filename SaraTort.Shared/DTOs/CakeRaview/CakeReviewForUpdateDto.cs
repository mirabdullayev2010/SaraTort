namespace SaraTort.Shared.DTOs.CakeRaview;

public class CakeReviewForUpdateDto
{
    public int Id { get; set; }
    public int CakeId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
}
