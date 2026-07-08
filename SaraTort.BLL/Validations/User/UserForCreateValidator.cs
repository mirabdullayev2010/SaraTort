using FluentValidation;
using SaraTort.Shared.DTOs.User;

namespace SaraTort.BLL.Validators.User;

public class UserForCreateValidator : AbstractValidator<UserForCreateDto>
{
    public UserForCreateValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .Matches(@"^\+998\d{9}$")
            .WithMessage("Telefon raqam +998901234567 formatida bo'lishi kerak.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(6)
            .MaximumLength(100);

        RuleFor(x => x.Age)
            .InclusiveBetween(14, 100);
    }
}