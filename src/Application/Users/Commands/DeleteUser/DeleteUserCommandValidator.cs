using FluentValidation;

namespace DrumSpace.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(v => v.UserId)
                .NotEmpty().WithMessage("UserId is required.");
        }
    }
}