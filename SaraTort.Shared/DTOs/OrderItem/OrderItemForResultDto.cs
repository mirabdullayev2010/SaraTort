namespace SaraTort.BLL.DTOs.OrderItem;

public class OrderItemForResultDto
{
    public int Id { get; set; }
    public int CakeOptionId { get; set; }
    public int Quantity { get; set; }

    public decimal PriceAtPurchase { get; set; }

    public string CakeName { get; set; } = string.Empty;
    public double WeightInKg { get; set; }
    public decimal ItemTotalPrice => PriceAtPurchase * Quantity;
}