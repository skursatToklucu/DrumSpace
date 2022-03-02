using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Rudiments.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DrumSpace.Application.Rudiments.Queries.GetRudimentsBySearch
{
    public class GetRudimentsBySearchQueryHandler : IRequestHandler<GetRudimentsBySearchQuery, ListResponse<RudimentDto>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        public GetRudimentsBySearchQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ListResponse<RudimentDto>> Handle(GetRudimentsBySearchQuery request, CancellationToken cancellationToken)
        {
            //TODO: Collate e dönmesi gerek
            var filterQuery = await _context.Rudiments.Where(x => EF.Functions.Like(x.Pattern, $"{request.Pattern}%"))
                .ProjectTo<RudimentDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);

            return new ListResponse<RudimentDto>
            {
                Data = filterQuery
            };
        }
    }
}