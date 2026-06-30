using SaraTort.Domain.Common;
using SaraTort.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaraTort.Domain.Entities.Orders;

[Table("Orders")]
public class Order : BaseEntity
{
    [Column("customer_name")]
    public string CustomerName { get; set; } = string.Empty;
    [Column("customer_phone")]
    public string CustomerPhone { get; set; } = string.Empty;
    [Column("delivery_address")]
    public string DeliveryAddress { get; set; } = string.Empty;
    [Column("custom_comment")]
    public string? CustomComment { get; set; }

    [Column("delivery_date")]
    public DateTime DeliveryDate { get; set; }

    [Column("total_amount")]
    public decimal TotalAmount { get; set; }

    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;

    public ICollection<orderItem> OrderItems { get; set; } = new List<orderItem>();
}