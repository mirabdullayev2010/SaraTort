using System.ComponentModel.DataAnnotations;

namespace SaraTort.BLL.DTOs.CartItem;

public class CartItemForUpdateDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    [Range(1, 100, ErrorMessage = "Tort soni kamida 1 ta bo'lishi shart.")]
    public int Quantity { get; set; }
}