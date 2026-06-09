using SaraTort.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaraTort.Domain.Entities.Catalog;

[Table("CakeOptions")]
public class CakeOption : BaseEntity
{
    [Column("cake_id")]
    public long CakeId { get; set; }
    public Cake Cake { get; set; } = null!;

    [Column("weight_in_kg")]
    public double WeightInKg { get; set; }
    [Column("price")]
    public decimal Price { get; set; }
    [Column("stock_quantity")]
    public int StockQuantity { get; set; }
}