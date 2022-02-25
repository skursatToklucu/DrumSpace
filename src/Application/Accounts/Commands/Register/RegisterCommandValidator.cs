using FluentValidation;
// ReSharper disable All

namespace DrumSpace.Application.Accounts.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(c => c.UserName)
                .NotEmpty().WithMessage("Kullanıcı adı boş geçilemez"); 

            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("Parola boş geçilemez"); 
            
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email boş geçilemez");
        }
    }
}