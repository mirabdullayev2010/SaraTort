namespace SaraTort.Shared.Options;

public class OrderOption
{
    public decimal MinimalOrderAmount { get; set; } = 5000;
    public int LeadTimeHours { get; set; } = 24;
}
