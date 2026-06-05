namespace SaraTort.Domain.Entities.Orders;

public class OrderItem
{
    public int Id { get; set; }

    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;

    public int CakeOptionId { get; set; } // Qaysi tort va qaysi vazndagi

    public int Quantity { get; set; } // Nechta buyurtma qilindi
    public decimal PriceAtPurchase { get; set; } // Sotib olingan paytdagi narxi
}