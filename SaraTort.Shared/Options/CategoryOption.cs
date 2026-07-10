using SaraTort.Shared.Options.Base;

namespace SaraTort.Shared.Options;

public class CategoryOption : BaseOption
{
    public bool ShowInactiveCategories { get; set; } = false;
    public int MaxMainPageCategories { get; set; } = 12;
}
