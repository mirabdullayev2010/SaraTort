namespace SaraTort.Shared.DTOs.OrderItem;

public class OrderItemForShortResultDto
{
    public long Id { get; set; }
    public long CakeOptionId { get; set; }
    public int Quantity { get; set; }

    public decimal PriceAtPurchase { get; set; }

    public string CakeName { get; set; }
    public double WeightInKg { get; set; }
    public decimal ItemTotalPrice => PriceAtPurchase * Quantity;
}
