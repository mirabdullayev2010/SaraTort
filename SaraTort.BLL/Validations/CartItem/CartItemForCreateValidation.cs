using FluentValidation;
using SaraTort.BLL.DTOs.CartItem;

namespace SaraTort.BLL.Validations.CartItem;

public class CartItemForCreateValidation : AbstractValidator<CartItemForCreateDto>
{
    public CartItemForCreateValidation()
    {
        RuleFor(x => x.SessionId)
            .NotEmpty()
            .WithMessage("Session kiritilishi majburiy!");
        RuleFor(x => x.CakeOptionId)
            .GreaterThan(0)
            .WithMessage("CakeOptionId 0 dan katta bo'lishi kerak!");
        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity 0 dan katta bo'lishi kerak!");
    }
}
