namespace SaraTort.BLL.DTOs.CartItem;

public class CartItemForResultDto
{
    public int Id { get; set; }
    public string SessionId { get; set; } = string.Empty;
    public int CakeOptionId { get; set; }
    public int Quantity { get; set; }

    public string CakeName { get; set; } = string.Empty;
    public string? CakeImageUrl { get; set; }
    public double WeightInKg { get; set; }
    public decimal Price { get; set; } 
    public decimal TotalPrice => Price * Quantity;
}