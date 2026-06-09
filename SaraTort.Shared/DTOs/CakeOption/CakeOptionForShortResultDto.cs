namespace SaraTort.Shared.DTOs.CakeOption;

public class CakeOptionForShortResultDto
{
    public long Id { get; set; }
    public long CakeId { get; set; }
    public double WeightInKg { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
