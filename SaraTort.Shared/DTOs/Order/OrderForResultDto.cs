using SaraTort.Domain.Enums;
using SaraTort.BLL.DTOs.OrderItem;

namespace SaraTort.BLL.DTOs.Order;

public class OrderForResultDto
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerPhone { get; set; } = string.Empty;
    public string DeliveryAddress { get; set; } = string.Empty;
    public string? CustomComment { get; set; }

    public DateTime OrderDate { get; set; }
    public DateTime DeliveryDate { get; set; }

    public decimal TotalAmount { get; set; }

    public OrderStatus Status { get; set; }
    public PaymentStatus PaymentStatus { get; set; }

    public List<OrderItemForResultDto> OrderItems { get; set; } = new();
}

public class OrderItemForResultDto
{
    public int Id { get; set; }
    public int CakeOptionId { get; set; }
    public int Quantity { get; set; }
    public decimal PriceAtPurchase { get; set; } // Sotib olingan paytdagi narxi

    // Front-endga qaysi tort ekanini srazu ko'rsatish uchun qo'shimcha ma'lumotlar
    public string CakeName { get; set; } = string.Empty;
    public double WeightInKg { get; set; }
}