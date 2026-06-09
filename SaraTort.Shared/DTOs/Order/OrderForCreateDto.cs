using System.ComponentModel.DataAnnotations;
using SaraTort.BLL.DTOs.OrderItem;

namespace SaraTort.BLL.DTOs.Order;

public class OrderForCreateDto
{
    [Required(ErrorMessage = "Ismingizni kiritishingiz shart!")]
    [StringLength(100, ErrorMessage = "Ism juda uzun.")]
    public string CustomerName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Telefon raqamingizni kiritish majburiy!")]
    [Phone(ErrorMessage = "Telefon raqami formati noto'g'ri.")]
    public string CustomerPhone { get; set; } = string.Empty;

    [Required(ErrorMessage = "Yetkazib berish manzili majburiy!")]
    public string DeliveryAddress { get; set; } = string.Empty;

    [StringLength(200, ErrorMessage = "Tort ustidagi yozuv juda uzun.")]
    public string? CustomComment { get; set; }

    [Required(ErrorMessage = "Yetkazib berish sanasi va vaqti majburiy!")]
    public DateTime DeliveryDate { get; set; }

    [Required(ErrorMessage = "Buyurtmada kamida bitta tort bo'lishi kerak.")]
    public List<OrderItemForCreateDto> OrderItems { get; set; } = new();
}