using SaraTort.Domain.Common;

namespace SaraTort.Domain.Entities.Catalog;

public class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<Cake> Cakes { get; set; } = new List<Cake>();
}