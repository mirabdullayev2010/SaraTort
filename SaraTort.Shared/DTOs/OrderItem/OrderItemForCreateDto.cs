using System.ComponentModel.DataAnnotations;

namespace SaraTort.BLL.DTOs.OrderItem;

public class OrderItemForCreateDto
{
    public int CakeOptionId { get; set; }
    public int Quantity { get; set; }
}