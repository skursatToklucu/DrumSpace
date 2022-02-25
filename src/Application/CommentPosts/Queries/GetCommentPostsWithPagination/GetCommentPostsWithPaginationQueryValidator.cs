using FluentValidation;

namespace DrumSpace.Application.CommentPosts.Queries.GetCommentPostsWithPagination
{
    public class GetCommentPostsWithPaginationQueryValidator : AbstractValidator<GetCommentPostsWithPaginationQuery>
    {
        public GetCommentPostsWithPaginationQueryValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");

            RuleFor(x => x.PostId)
                .GreaterThanOrEqualTo(1).WithMessage("PostId at least greater than or equal to 1.")
                .NotEmpty().WithMessage("PostId is required.");
        }
    }
}