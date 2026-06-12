using FluentValidation;
using SaraTort.BLL.DTOs.CartItem;

namespace SaraTort.BLL.Validations.CartItem;

public class CartItemForUpdateValidation : AbstractValidator<CartItemForUpdateDto>
{
    public CartItemForUpdateValidation()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Id 0 dan katta bo'lishi kerak!");
        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity 0 dan katta bo'lishi kerak!");
    }
}
