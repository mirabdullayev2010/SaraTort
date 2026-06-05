using SaraTort.Domain.Common;

namespace SaraTort.Domain.Entities.Catalog;

public class CakeOption : BaseEntity
{
    public int CakeId { get; set; }
    public Cake Cake { get; set; } = null!;

    public double WeightInKg { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
}