using SaraTort.Domain.Common;
using SaraTort.Domain.Enums;

namespace SaraTort.Domain.Entities.Orders;

public class Order : BaseEntity
{
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerPhone { get; set; } = string.Empty;
    public string DeliveryAddress { get; set; } = string.Empty;
    public string? CustomComment { get; set; }

    public DateTime DeliveryDate { get; set; }

    public decimal TotalAmount { get; set; }

    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}