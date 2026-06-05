namespace SaraTort.Domain.Entities.Catalog;

public class CakeReview
{
    public int Id { get; set; }
    public int CakeId { get; set; }
    public Cake Cake { get; set; } = null!;

    public string CustomerName { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
    public int Rating { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}