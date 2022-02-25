using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Posts.Queries.Dtos;
using MediatR;

namespace DrumSpace.Application.Posts.Queries.GetPostDetailById
{
    public class GetPostDetailByIdQuery : IRequest<SingleResponse<PostDetailDto>>
    {
        public int Id { get; set; }
    }
}