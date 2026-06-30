namespace SaraTort.Shared.DTOs.OrderItem;

public class OrderItemForUpdateDto
{
    public long Id { get; set; }
    public long OrderId { get; set; }
    public int Quantity { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
}
