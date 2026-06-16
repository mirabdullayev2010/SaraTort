using FluentValidation;
using SaraTort.BLL.DTOs.Order;

namespace SaraTort.BLL.Validations.Order;

public class OrderForUpdateStatusValidation : AbstractValidator<OrderForUpdateStatusDto>
{
    public OrderForUpdateStatusValidation()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Noto'g'ri buyurtma ID si kiritildi");
        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Bunday buyurtma statusi mavjud emas");
        RuleFor(x => x.PaymentStatus)
            .IsInEnum().WithMessage("Bunday tolov statusi mavjud emas");
    }
}
