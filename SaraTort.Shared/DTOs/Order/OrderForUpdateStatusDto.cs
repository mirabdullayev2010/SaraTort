using System.ComponentModel.DataAnnotations;
using SaraTort.Domain.Enums;

namespace SaraTort.BLL.DTOs.Order;

public class OrderForUpdateStatusDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    public OrderStatus Status { get; set; }

    [Required]
    public PaymentStatus PaymentStatus { get; set; }
}