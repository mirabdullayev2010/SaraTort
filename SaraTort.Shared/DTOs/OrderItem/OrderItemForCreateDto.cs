using System.ComponentModel.DataAnnotations;

namespace SaraTort.BLL.DTOs.OrderItem;

public class OrderItemForCreateDto
{
    [Required(ErrorMessage = "Qaysi tort o'lchami (CakeOptionId) ekanligi majburiy!")]
    public int CakeOptionId { get; set; }

    [Required]
    [Range(1, 100, ErrorMessage = "Buyurtma qilinayotgan tort soni kamida 1 ta bo'lishi kerak.")]
    public int Quantity { get; set; }
}