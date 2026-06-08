using FluentValidation;
using SaraTort.BLL.DTOs.CakeOption;

namespace SaraTort.BLL.Validators.CakeOption;

public class CakeOptionForCreateValidator : AbstractValidator<CakeOptionForCreateDto>
{
    public CakeOptionForCreateValidator()
    {
        RuleFor(x => x.CakeId)
            .GreaterThan(0)
            .WithMessage("Qaysi tortga tegishli ekanligi (CakeId) majburiy!");

        RuleFor(x => x.WeightInKg)
            .GreaterThanOrEqualTo(0.1)
            .WithMessage("Vazn 0.1 kg dan kam bo'lishi mumkin emas.")
            .LessThanOrEqualTo(50)
            .WithMessage("Vazn 50 kg dan oshmasligi kerak.");

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Narx manfiy son bo'lishi mumkin emas.");

        RuleFor(x => x.StockQuantity)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Tort soni 0 dan kam bo'lishi mumkin emas.");
    }
}