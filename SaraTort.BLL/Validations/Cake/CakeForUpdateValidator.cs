using FluentValidation;
using SaraTort.BLL.DTOs.Cake;

namespace SaraTort.BLL.Validators.Cake;

public class CakeForUpdateValidator : AbstractValidator<CakeForUpdateDto>
{
    public CakeForUpdateValidator()
    {

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Tort nomi majburiy!")
            .MaximumLength(100)
            .WithMessage("Tort nomi 100 ta belgidan oshmasligi kerak.");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Tort tavsifi majburiy!")
            .MaximumLength(1000)
            .WithMessage("Tavsif 1000 ta belgidan oshmasligi kerak.");

        RuleFor(x => x.CategoryId)
            .GreaterThan(0)
            .WithMessage("Kategoriya tanlanishi shart!");

        RuleFor(x => x.ImageUrl)
            .MaximumLength(500)
            .WithMessage("Rasm URL manzili juda uzun.")
            .When(x => !string.IsNullOrWhiteSpace(x.ImageUrl));
    }
}