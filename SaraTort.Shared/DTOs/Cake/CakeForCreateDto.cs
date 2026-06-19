using System.ComponentModel.DataAnnotations;

namespace SaraTort.BLL.DTOs.Cake;

public class CakeForCreateDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string? ImageUrl { get; set; }
    public long CategoryId { get; set; }
}