using FluentValidation;
using SaraTort.BLL.DTOs.Order;

namespace SaraTort.BLL.Validations.Order;

public class OrderForCreateValidation : AbstractValidator<OrderForCreateDto>
{
    public OrderForCreateValidation()
    {
        RuleFor(x => x.CustomerName)
            .NotEmpty()
            .WithMessage("Ismingizni kiritishingiz shart!")
            .MaximumLength(100)
            .WithMessage("Ism juda uzun maksimal 100 ta belgi bolishi kerak");

        RuleFor(x => x.CustomerPhone)
            .NotEmpty()
            .WithMessage("Telefon raqamingizni kiritishingiz majburiy!")
            .Matches(@"^\+?998\d{9}$")
            .WithMessage("Telefon raqami formati notogri masalan: +998 90 781 81 77");

        RuleFor(x => x.DeliveryAddress)
            .NotEmpty()
            .WithMessage("Yetkazib berish manzili kiritilishi majburiy!")
            .MaximumLength(200).WithMessage("Manzil juda uzun maksimal 200 ta belgi bolishi kerak!");

        RuleFor(x => x.CustomComment)
            .MinimumLength(200).WithMessage("Tort ustidagi yozuv juda uzun maksimal 200 ta belgi bolishi kerak!")
            .When(x => !string.IsNullOrEmpty(x.CustomComment));

        RuleFor(x => x.DeliveryDate)
            .NotEmpty().WithMessage("Yetkazib berish sanasi kiritilishi majburiy!")
            .GreaterThan(DateTime.Now.AddHours(2)).WithMessage("Yetkazib berish sanasi joriy vaqt dan keyin bo'lishi kerak!");

        RuleFor(x => x.OrderItems)
            .NotEmpty().WithMessage("Buyurtmada kamida bitta tort bo'lishi kerak.")
            .Must(items => items != null && items.Count > 0).WithMessage("Buyurtma ro'yxati bo'sh bo'lishi mumkin emas.");
    }
}

