using SaraTort.BLL.DTOs.CakeOption;
using SaraTort.BLL.DTOs.CakeReview;

namespace SaraTort.BLL.DTOs.Cake;

public class CakeForResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? ImageUrl { get; set; }
    public long CategoryId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public List<CakeReviewForResultDto> Reviews { get; set; } = new();
    public List<CakeOptionForResultDto> Options { get; set; } = new();
}