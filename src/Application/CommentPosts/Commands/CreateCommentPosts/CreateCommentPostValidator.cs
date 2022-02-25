using FluentValidation;

namespace DrumSpace.Application.CommentPosts.Commands.CreateCommentPosts
{
    public class CreateCommentPostValidator : AbstractValidator<CreateCommentPost>
    {
        public CreateCommentPostValidator()
        {
            RuleFor(v => v.Description)
                .NotEmpty().WithMessage("Description is required.");

            RuleFor(v => v.PostId)
                .NotEmpty().WithMessage("PostId is required.");
        }
    }
}