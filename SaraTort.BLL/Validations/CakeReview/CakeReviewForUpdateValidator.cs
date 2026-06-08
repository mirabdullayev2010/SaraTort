using FluentValidation;
using SaraTort.Shared.DTOs.CakeRaview;

namespace SaraTort.BLL.Validators.CakeReview;

public class CakeReviewForUpdateValidator : AbstractValidator<CakeReviewForUpdateDto>
{
    public CakeReviewForUpdateValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Review ID noto'g'ri.");

        RuleFor(x => x.CakeId)
            .GreaterThan(0)
            .WithMessage("Tort tanlanishi shart!");

        RuleFor(x => x.CustomerName)
            .NotEmpty()
            .WithMessage("Ismingizni kiritish shart!")
            .MaximumLength(50)
            .WithMessage("Ism 50 ta belgidan oshmasligi kerak.");
    }
}