using System.ComponentModel.DataAnnotations.Schema;

namespace SaraTort.Domain.Entities.Orders;

[Table("OrderItems")]
public class orderItem
{
    [Column("id")]
    public long Id { get; set; }
    [Column("order_id")]
    public long OrderId { get; set; }
    [Column("order")]
    public Order Order { get; set; } = null!;

    [Column("quantity")]
    public int Quantity { get; set; } 
    [Column("price_at_purchase")]
    public decimal PriceAtPurchase { get; set; } 
}