using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Tags.Queries.Dtos;
using MediatR; 

namespace DrumSpace.Application.Tags.Queries.GetTagsDetailById
{
    public class GetTagsDetailByIdQuery : IRequest<SingleResponse<TagDto>>
    {
        public int Id { get; set; }
    }
}