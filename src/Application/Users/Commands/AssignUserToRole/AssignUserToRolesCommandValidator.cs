using FluentValidation;

namespace DrumSpace.Application.Users.Commands.AssignUserToRole
{
    public class AssignUserToRolesCommandValidator : AbstractValidator<AssignUserToRolesCommand>
    {
        public AssignUserToRolesCommandValidator()
        {
            RuleFor(v => v.RoleIds)
                .NotEmpty().WithMessage("RoleIds is required.");

            RuleFor(v => v.UserId)
                .NotEmpty().WithMessage("UserId is required.");
        }
    }
}