using System.ComponentModel.DataAnnotations.Schema;

namespace SaraTort.Domain.Entities.Catalog;

[Table("CakeReviews")]
public class CakeReview
{
    [Column("id")]
    public long Id { get; set; }
    [Column("cake_id")]
    public long CakeId { get; set; }
    public Cake Cake { get; set; } = null!;

    [Column("customer_name")]
    public string CustomerName { get; set; } = string.Empty;
    [Column("comment")]
    public string Comment { get; set; } = string.Empty;
    [Column("rating")]
    public int Rating { get; set; }
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}