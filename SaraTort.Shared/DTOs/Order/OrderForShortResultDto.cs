using SaraTort.BLL.DTOs.OrderItem;
using SaraTort.Domain.Enums;

namespace SaraTort.Shared.DTOs.Order;

public class OrderForShortResultDto
{
    public long Id { get; set; }
    public string CustomerName { get; set; }
    public string CustomerPhone { get; set; }
    public string DeliveryAddress { get; set; }
    public string? CustomComment { get; set; }

    public DateTime OrderDate { get; set; }
    public DateTime DeliveryDate { get; set; }

    public decimal TotalAmount { get; set; }

    public OrderStatus Status { get; set; }
    public PaymentStatus PaymentStatus { get; set; }

    public List<OrderItemForResultDto> OrderItems { get; set; } = new();
}
