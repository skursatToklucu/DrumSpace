using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Menus.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DrumSpace.Application.Menus.Queries.GetMenuDetailById
{
    public class GetMenuDetailByIdQueryHandler : IRequestHandler<GetMenuDetailByIdQuery, SingleResponse<MenuDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetMenuDetailByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SingleResponse<MenuDto>> Handle(GetMenuDetailByIdQuery request,
            CancellationToken cancellationToken)
        {
            SingleResponse<MenuDto> singleResponse = new()
            {
                Data = await _context.Menus.Where(x => x.Id == request.Id)
                    .ProjectTo<MenuDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken)
            };
            return singleResponse;
        }
    }
}