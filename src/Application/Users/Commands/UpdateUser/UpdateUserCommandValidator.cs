using FluentValidation;

namespace DrumSpace.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator: AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(v => v.UserId)
                .NotEmpty().WithMessage("UserId is required.");
            
            RuleFor(v => v.Email)
                .NotEmpty().WithMessage("Email is required.");
            
            RuleFor(v => v.UserName)
                .NotEmpty().WithMessage("UserName is required.");
        }
    }
}