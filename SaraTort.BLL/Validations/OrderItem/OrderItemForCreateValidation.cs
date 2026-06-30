using FluentValidation;
using SaraTort.BLL.DTOs.OrderItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaraTort.BLL.Validations.OrderItem;

public class OrderItemForCreateValidation : AbstractValidator <OrderItemForCreateDto>
{
    public OrderItemForCreateValidation()
    {
   
        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity 0 dan katta bo'lishi gerekir!");
    }
}
