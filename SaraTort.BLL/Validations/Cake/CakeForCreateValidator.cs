using FluentValidation;
using SaraTort.BLL.DTOs.Cake;
namespace SaraTort.Validators;

public class CakeForCreateValidator : AbstractValidator<CakeForCreateDto>
{
    public CakeForCreateValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Tort nomi majburiy kiritilishi kerak!")
            .MaximumLength(100)
            .WithMessage("Tort nomi 100 ta belgidan oshmasligi kerak.");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Tort haqida tavsif (description) yozish majburiy!")
            .MaximumLength(1000)
            .WithMessage("Tavsif 1000 ta belgidan oshmasligi kerak.");

        RuleFor(x => x.CategoryId)
            .GreaterThan(0)
            .WithMessage("Kategoriya tanlanishi shart!");

        RuleFor(x => x.ImageUrl)
            .MaximumLength(500)
            .WithMessage("Rasm havolasi juda uzun.")
            .When(x => !string.IsNullOrWhiteSpace(x.ImageUrl));
    }
}