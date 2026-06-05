using System.ComponentModel.DataAnnotations;

namespace SaraTort.BLL.DTOs.CartItem;

public class CartItemForCreateDto
{
    [Required(ErrorMessage = "Foydalanuvchi sessiyasi (SessionId) majburiy!")]
    public string SessionId { get; set; } = string.Empty;

    [Required(ErrorMessage = "Qaysi tort o'lchami (CakeOptionId) ekanligi majburiy!")]
    public int CakeOptionId { get; set; }

    [Required]
    [Range(1, 100, ErrorMessage = "Savatchaga kamida 1 ta tort qo'shish kerak.")]
    public int Quantity { get; set; }
}