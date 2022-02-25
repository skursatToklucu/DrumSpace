using FluentValidation;

namespace DrumSpace.Application.Accounts.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(c => c.UserName)
                .NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");

            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("Parola boş geçilemez");
        }
    }
}