using SaraTort.BLL.DTOs.CakeOption;
using SaraTort.BLL.DTOs.CakeReview;

namespace SaraTort.BLL.DTOs.Cake;

public class CakeForResultDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public int CategoryId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public List<CakeReviewForResultDto> Reviews { get; set; } = new();
    public List<CakeOptionForResultDto> Options { get; set; } = new();
}