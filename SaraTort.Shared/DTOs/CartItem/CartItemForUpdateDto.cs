using System.ComponentModel.DataAnnotations;

namespace SaraTort.BLL.DTOs.CartItem;

public class CartItemForUpdateDto
{
    public int Id { get; set; }
    public int Quantity { get; set; }
}