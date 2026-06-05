namespace SaraTort.Domain.Entities.Orders;

public class CartItem
{
    public int Id { get; set; }
    public string SessionId { get; set; } = string.Empty;

    public int CakeOptionId { get; set; }
    public int Quantity { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}