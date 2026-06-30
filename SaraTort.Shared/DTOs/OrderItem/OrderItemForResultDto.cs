namespace SaraTort.BLL.DTOs.OrderItem;

public class OrderItemForResultDto
{
    public long Id { get; set; }
    public int Quantity { get; set; }

    public decimal PriceAtPurchase { get; set; }

    public string CakeName { get; set; }
    public double WeightInKg { get; set; }
    public decimal ItemTotalPrice => PriceAtPurchase * Quantity;
}