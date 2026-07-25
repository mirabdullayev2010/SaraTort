using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace SaraTort.BLL.DTOs.Cake;

public class CakeForCreateDto
{
    public int Price { get; set; }
    public IFormFile Image { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? ImageUrl { get; set; }
    public long CategoryId { get; set; }
    public string Title { get; set; }
}