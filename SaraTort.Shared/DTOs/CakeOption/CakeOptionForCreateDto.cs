using System.ComponentModel.DataAnnotations;

namespace SaraTort.BLL.DTOs.CakeOption;

public class CakeOptionForCreateDto
{
    public int CakeId { get; set; }
    public double WeightInKg { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
}