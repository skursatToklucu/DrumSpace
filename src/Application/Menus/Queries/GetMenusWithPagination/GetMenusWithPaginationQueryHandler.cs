using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Mappings;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Menus.Queries.Dtos;
using MediatR;

namespace DrumSpace.Application.Menus.Queries.GetMenusWithPagination
{
    public class
        GetMenusWithPaginationQueryHandler : IRequestHandler<GetMenusWithPaginationQuery, PagedResponse<MenuDto>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetMenusWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<PagedResponse<MenuDto>> Handle(GetMenusWithPaginationQuery request,
            CancellationToken cancellationToken)
        {
            PagedResponse<MenuDto> paginatedListAsync = await _context.Menus
                .OrderBy(x => x.Name)
                .ProjectTo<MenuDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return paginatedListAsync;
        }
    }
}