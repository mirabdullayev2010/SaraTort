using System.ComponentModel.DataAnnotations.Schema;

namespace SaraTort.Domain.Entities.Orders;

[Table("CartItems")]
public class CartItem
{
    [Column("id")]
    public long Id { get; set; }
    [Column("session_id")]
    public string SessionId { get; set; } = string.Empty;

    [Column("cake_option_id")]
    public long CakeOptionId { get; set; }
    [Column("quantity")]
    public int Quantity { get; set; }
    
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}