using SaraTort.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaraTort.Domain.Entities.Catalog;

[Table("Cakes")]
public class Cake : BaseEntity
{
    [Column("price"), Required]
    public decimal Price { get; set; }

    [Column("title"), Required]
    public string Title { get; set; }

    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("description"), Required]
    public string Description { get; set; } = string.Empty;

    [Column("image_url")]
    public string? ImageUrl { get; set; }

    [Column("category_id")]
    public int CategoryId { get; set; }

    // SHU YERGA [ForeignKey(nameof(CategoryId))] QO'SHILDI
    [ForeignKey(nameof(CategoryId))]
    [Column("category")]
    public Category Category { get; set; } = null!;

    public ICollection<CakeReview> Reviews { get; set; } = new List<CakeReview>();
}