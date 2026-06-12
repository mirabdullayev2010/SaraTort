using FluentValidation;
using SaraTort.BLL.DTOs.Category;

namespace SaraTort.BLL.Validations.Category;

public class CategoryForCreateValidation : AbstractValidator<CategoryForCreateDto>
{
    public CategoryForCreateValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Category nomi kiritilishi majburiy!");
        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Category tavsifi kiritilishi majburiy!");
    }
}
