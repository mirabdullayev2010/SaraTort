using SaraTort.Shared.Options.Base;

namespace SaraTort.Shared.Options;

public class CakeOption : BaseOption
{
    public int MinRating { get; set; } = 1;
    public int MaxRating { get; set; } = 5;
    public bool RequireApproval { get; set; } = true;
}
