using System.ComponentModel.DataAnnotations;

namespace SaraTort.BLL.DTOs.CakeOption;

public class CakeOptionForUpdateDto
{
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Qaysi tortga tegishli ekanligi (CakeId) majburiy!")]
    public int CakeId { get; set; }

    [Required(ErrorMessage = "Vazn kiritilishi shart!")]
    [Range(0.1, 50.0, ErrorMessage = "Vazn 0.1 kg dan 50 kg gacha bo'lishi mumkin.")]
    public double WeightInKg { get; set; }

    [Required(ErrorMessage = "Narx kiritilishi shart!")]
    [Range(0, double.MaxValue, ErrorMessage = "Narx manfiy son bo'lishi mumkin emas.")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Omborda nechta qolgani (Stock) majburiy!")]
    [Range(0, int.MaxValue, ErrorMessage = "Tort soni 0 dan kam bo'lishi mumkin emas.")]
    public int StockQuantity { get; set; }
}