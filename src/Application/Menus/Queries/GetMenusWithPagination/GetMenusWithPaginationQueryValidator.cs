﻿using FluentValidation;

namespace DrumSpace.Application.Menus.Queries.GetMenusWithPagination
{
    public class GetMenusWithPaginationQueryValidator : AbstractValidator<GetMenusWithPaginationQuery>
    {
        public GetMenusWithPaginationQueryValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}