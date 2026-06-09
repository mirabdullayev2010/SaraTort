using SaraTort.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaraTort.Domain.Entities.Catalog;

[Table("Categories")]
public class Category : BaseEntity
{
    [Column("name")]
    public string Name { get; set; } = string.Empty;
    [Column("description")]
    public string? Description { get; set; }
    [Column("is_active")]
    public bool IsActive { get; set; } = true;

    public ICollection<Cake> Cakes { get; set; } = new List<Cake>();
}