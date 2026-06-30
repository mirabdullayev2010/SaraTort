using FluentValidation;
using SaraTort.Shared.DTOs.OrderItem;

namespace SaraTort.BLL.Validations.OrderItem;

public class OrderItemForUpdateValidation : AbstractValidator<OrderItemForUpdateDto>
{
    public OrderItemForUpdateValidation()
    {
        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity 0 dan katta bo'lishi kerak!");
    }
}
