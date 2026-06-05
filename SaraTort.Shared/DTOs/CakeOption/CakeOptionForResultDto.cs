namespace SaraTort.BLL.DTOs.CakeOption;

public class CakeOptionForResultDto
{
    public int Id { get; set; }
    public int CakeId { get; set; }
    public double WeightInKg { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}