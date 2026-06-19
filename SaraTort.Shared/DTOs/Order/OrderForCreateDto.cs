using SaraTort.BLL.DTOs.OrderItem;

namespace SaraTort.BLL.DTOs.Order;

public class OrderForCreateDto
{
    public string CustomerName { get; set; }
    public string CustomerPhone { get; set; }
    public string DeliveryAddress { get; set; }
    public string? CustomComment { get; set; }
    public DateTime DeliveryDate { get; set; }
    public List<OrderItemForCreateDto> OrderItems { get; set; } = new();
}