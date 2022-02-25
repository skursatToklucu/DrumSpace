using FluentValidation;

namespace DrumSpace.Application.Tags.Queries.GetTagsDetailById
{
    public class GetTagsDetailByIdQueryValidator : AbstractValidator<GetTagsDetailByIdQuery>
    {
        public GetTagsDetailByIdQueryValidator()
        { 
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id 0'dan küçük olamaz.");
            RuleFor(x => x.Id).LessThan(int.MaxValue).WithMessage($"Id {int.MaxValue}'dan büyük olamaz"); 
        }
    }
}