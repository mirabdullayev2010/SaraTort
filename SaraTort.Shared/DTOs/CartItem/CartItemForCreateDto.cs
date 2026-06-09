namespace SaraTort.BLL.DTOs.CartItem;

public class CartItemForCreateDto
{
    public string SessionId { get; set; }
    public long CakeOptionId { get; set; }
    public int Quantity { get; set; }
}