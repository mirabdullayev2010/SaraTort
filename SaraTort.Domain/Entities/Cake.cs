using SaraTort.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaraTort.Domain.Entities.Catalog;

[Table("Cakes")]
public class Cake : BaseEntity
{
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("description"), Required]
    public string Description { get; set; } = string.Empty;

    [Column("image_url")]
    public string? ImageUrl { get; set; }

    [Column("category_id")]
    public long CategoryId { get; set; }

    [Column("category")]
    public Category Category { get; set; } = null!;

    public ICollection<CakeOption> Options { get; set; } = new List<CakeOption>();
    public ICollection<CakeReview> Reviews { get; set; } = new List<CakeReview>();
}