namespace SaraTort.Shared.DTOs.CartItem;

public class CartltemForShortResultDto
{
    public long Id { get; set; }
    public string SessionId { get; set; }
    public long CakeOptionId { get; set; }
    public int Quantity { get; set; }

    public string CakeName { get; set; }
    public string? CakeImageUrl { get; set; }
    public double WeightInKg { get; set; }
    public decimal Price { get; set; }
    public decimal TotalPrice => Price * Quantity;
}
