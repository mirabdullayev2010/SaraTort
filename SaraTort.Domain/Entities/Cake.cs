using SaraTort.Domain.Common;

namespace SaraTort.Domain.Entities.Catalog;

public class Cake : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    public ICollection<CakeOption> Options { get; set; } = new List<CakeOption>();
    public ICollection<CakeReview> Reviews { get; set; } = new List<CakeReview>();
}