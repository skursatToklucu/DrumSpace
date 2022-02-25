using FluentValidation;

namespace DrumSpace.Application.Accounts.Commands.ConfirmEmail
{
    public class ConfirmCommandValidator : AbstractValidator<ConfirmCommand>
    {
        public ConfirmCommandValidator()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email boş geçilemez");

            RuleFor(c => c.Token)
                .NotEmpty().WithMessage("Token boş geçilemez");
        }
    }
}