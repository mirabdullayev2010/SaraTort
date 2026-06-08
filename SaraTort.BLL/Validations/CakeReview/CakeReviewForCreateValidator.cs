using FluentValidation;
using SaraTort.BLL.DTOs.CakeReview;

namespace SaraTort.BLL.Validators.CakeReview;

public class CakeReviewForCreateValidator : AbstractValidator<CakeReviewForCreateDto>
{
    public CakeReviewForCreateValidator()
    {
        RuleFor(x => x.CakeId)
            .GreaterThan(0)
            .WithMessage("Tort tanlanishi shart!");

        RuleFor(x => x.CustomerName)
            .NotEmpty()
            .WithMessage("Ismingizni kiritishingiz shart!")
            .MaximumLength(50)
            .WithMessage("Ism 50 ta belgidan oshmasligi kerak.");

        RuleFor(x => x.Comment)
            .NotEmpty()
            .WithMessage("Fikringizni qoldirishingiz shart!")
            .MaximumLength(500)
            .WithMessage("Izoh 500 ta belgidan oshmasligi kerak.");

        RuleFor(x => x.Rating)
            .InclusiveBetween(1, 5)
            .WithMessage("Baho 1 dan 5 gacha bo'lishi shart.");
    }
}