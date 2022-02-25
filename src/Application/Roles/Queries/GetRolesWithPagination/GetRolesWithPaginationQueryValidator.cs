using FluentValidation;

namespace DrumSpace.Application.Roles.Queries.GetRolesWithPagination
{
    public class GetRolesWithPaginationQueryValidator : AbstractValidator<GetRolesWithPaginationQuery>
    {
        public GetRolesWithPaginationQueryValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}