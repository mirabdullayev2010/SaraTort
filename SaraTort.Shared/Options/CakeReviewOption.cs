using SaraTort.Shared.Options.Base;

namespace SaraTort.Shared.Options;

public class CakeReviewOption : BaseOption
{
    public int MinRating { get; set; } = 1;
    public int MaxRating { get; set; } = 5;
    public bool RequireApproval { get; set; } = true;
}
