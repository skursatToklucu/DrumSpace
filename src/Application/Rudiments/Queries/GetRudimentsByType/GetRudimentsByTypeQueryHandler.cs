using System.Collections.Generic;
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
using Microsoft.EntityFrameworkCore;

namespace DrumSpace.Application.Rudiments.Queries.GetRudimentsByType
{
    public class GetRudimentsByTypeQueryHandler : IRequestHandler<GetRudimentsByTypeQuery, ListResponse<RudimentDto>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        public GetRudimentsByTypeQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ListResponse<RudimentDto>> Handle(GetRudimentsByTypeQuery request, CancellationToken cancellationToken)
        {
            var rudiments = await _context.Rudiments.Where(x => x.Type == request.Type)
                .ProjectTo<RudimentDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ListResponse<RudimentDto>
            {
                Data = rudiments
            };

        }
    }
}