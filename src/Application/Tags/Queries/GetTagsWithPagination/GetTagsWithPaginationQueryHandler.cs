using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Mappings;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Tags.Queries.Dtos;
using MediatR;

namespace DrumSpace.Application.Tags.Queries.GetTagsWithPagination
{
    public class GetTagsWithPaginationQueryHandler : IRequestHandler<GetTagsWithPaginationQuery, PagedResponse<TagDto>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetTagsWithPaginationQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<PagedResponse<TagDto>> Handle(GetTagsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Tags
                .OrderBy(x => x.Title)
                .ProjectTo<TagDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}