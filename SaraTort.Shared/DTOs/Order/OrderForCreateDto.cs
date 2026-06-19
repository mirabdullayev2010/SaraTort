using System.ComponentModel.DataAnnotations;
using SaraTort.BLL.DTOs.OrderItem;

namespace SaraTort.BLL.DTOs.Order;

public class OrderForCreateDto
{
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerPhone { get; set; } = string.Empty;
    public string DeliveryAddress { get; set; } = string.Empty;
    public string? CustomComment { get; set; }
    public DateTime DeliveryDate { get; set; }
    public List<OrderItemForCreateDto> OrderItems { get; set; } = new();
}