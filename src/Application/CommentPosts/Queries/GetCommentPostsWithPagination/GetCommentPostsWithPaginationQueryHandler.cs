using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DrumSpace.Application.CommentPosts.Queries.Dtos;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Mappings;
using DrumSpace.Application.Common.Models.Response;
using MediatR;

namespace DrumSpace.Application.CommentPosts.Queries.GetCommentPostsWithPagination
{
    public class GetCommentPostsWithPaginationQueryHandler : IRequestHandler<GetCommentPostsWithPaginationQuery, PagedResponse<CommentPostsDto>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetCommentPostsWithPaginationQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<PagedResponse<CommentPostsDto>> Handle(GetCommentPostsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            PagedResponse<CommentPostsDto> paginatedListAsync = await _context.CommentPosts
                .Where(c=>c.PostId == request.PostId)
                .OrderBy(x => x.Description)
                .ProjectTo<CommentPostsDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return paginatedListAsync;
        }
    }
}