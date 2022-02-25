using DrumSpace.Application.Tags.Queries.GetTagsDetailById;
using FluentValidation;

namespace DrumSpace.Application.Menus.Queries.GetMenuDetailById
{
    public class GetMenuDetailByIdQueryValidator : AbstractValidator<GetTagsDetailByIdQuery>
    {
        public GetMenuDetailByIdQueryValidator()
        { 
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id 0'dan küçük olamaz.");
            RuleFor(x => x.Id).LessThan(int.MaxValue).WithMessage($"Id {int.MaxValue}'dan büyük olamaz"); 
        }
    }
}