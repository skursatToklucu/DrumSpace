using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Mappings;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Posts.Queries.Dtos;
using DrumSpace.Application.Users.Queries.Dtos;
using MediatR;

namespace DrumSpace.Application.Posts.Queries.GetPostsWithPagination
{
    public class GetPostsWithPaginationQueryHandler : IRequestHandler<GetPostsWithPaginationQuery, PagedResponse<PostDto>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        private readonly IUserService _userService;

        public GetPostsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper,
            IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
            _context = context;
        }

        public async Task<PagedResponse<PostDto>> Handle(GetPostsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            PagedResponse<PostDto> paginatedListAsync = await _context.Posts
                .OrderBy(x => x.Title)
                .ProjectTo<PostDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            List<string> createdBy = paginatedListAsync.Data.Select(x => x.CreatedBy).ToList();
            List<UserDto> users = await _userService.Users(createdBy);

            paginatedListAsync.Data.ToList().ForEach(c =>
            {
                c.CommentCount = _context.CommentPosts.Count(x => x.PostId == c.Id);
                c.CreatedBy = users.Find(x => x.Id == c.CreatedBy)?.UserName;
            });

            return paginatedListAsync;
        }
    }
}