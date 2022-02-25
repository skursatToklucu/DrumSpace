using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Posts.Queries.Dtos;
using DrumSpace.Application.Users.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DrumSpace.Application.Posts.Queries.GetPostDetailById
{
    public class GetPostDetailByIdQueryHandler : IRequestHandler<GetPostDetailByIdQuery, SingleResponse<PostDetailDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IApplicationDbContext _context;

        public GetPostDetailByIdQueryHandler(IMapper mapper, IApplicationDbContext context, IUserService userService)
        {
            _mapper = mapper;
            _context = context;
            _userService = userService;
        }

        public async Task<SingleResponse<PostDetailDto>> Handle(GetPostDetailByIdQuery request, CancellationToken cancellationToken)
        {
            PostDetailDto post = await _context.Posts.Where(x => x.Id == request.Id)
                .ProjectTo<PostDetailDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            List<UserDto> users = await _userService.Users(new List<string> { post.CreatedBy });

            post.CommentCount = _context.CommentPosts.Count(x => x.PostId == post.Id);
            post.CreatedBy = users.Find(x => x.Id == post.CreatedBy)?.UserName;

            SingleResponse<PostDetailDto> singleResponse = new() { Data = post };

            return singleResponse;
        }
    }
}