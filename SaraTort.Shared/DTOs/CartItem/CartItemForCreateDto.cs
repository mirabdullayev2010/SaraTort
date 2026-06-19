using System.ComponentModel.DataAnnotations;

namespace SaraTort.BLL.DTOs.CartItem;

public class CartItemForCreateDto
{
    public string SessionId { get; set; } = string.Empty;
    public int CakeOptionId { get; set; }
    public int Quantity { get; set; }
}