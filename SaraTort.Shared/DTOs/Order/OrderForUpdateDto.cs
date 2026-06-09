using SaraTort.Domain.Enums;

namespace SaraTort.BLL.DTOs.Order;

public class OrderForUpdateDto
{
    public long Id { get; set; }
    public OrderStatus Status { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
}