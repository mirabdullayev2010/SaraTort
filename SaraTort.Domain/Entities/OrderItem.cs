namespace SaraTort.Domain.Entities.Orders;

public class OrderItem
{
    public int Id { get; set; }

    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;

    public int CakeOptionId { get; set; }

    public int Quantity { get; set; } 
    public decimal PriceAtPurchase { get; set; } 
}