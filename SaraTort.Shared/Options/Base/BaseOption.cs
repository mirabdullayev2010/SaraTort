namespace SaraTort.Shared.Options.Base;

public class BaseOption
{
    public bool IsEnabled { get; set; } = true;
    public int CacheDurationMinutes { get; set; } = 10;
}
