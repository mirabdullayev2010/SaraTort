using FluentValidation;
using SaraTort.Shared.DTOs.OrderItem;

namespace SaraTort.BLL.Validations.OrderItem;

public class OrderItemForUpdateValidation : AbstractValidator<OrderItemForUpdateDto>
{
    public OrderItemForUpdateValidation()
    {
        RuleFor(x => x.CakeOptionId)
            .GreaterThan(0)
            .WithMessage("CakeOptionId 0 dan katta bo'lishi kerak!");
        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity 0 dan katta bo'lishi kerak!");
    }
}
