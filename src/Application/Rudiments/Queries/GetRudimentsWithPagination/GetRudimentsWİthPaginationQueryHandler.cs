using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Mappings;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Rudiments.Queries.Dtos;
using MediatR;

namespace DrumSpace.Application.Rudiments.Queries.GetRudimentsWithPagination
{
    public class GetRudimentsWİthPaginationQueryHandler : IRequestHandler<GetRudimentsWithPaginationQuery, PagedResponse<RudimentDto>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetRudimentsWİthPaginationQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedResponse<RudimentDto>> Handle(GetRudimentsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Rudiments
                .OrderBy(x => x.Type)
                .ProjectTo<RudimentDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}