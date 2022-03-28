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
            var filterQuery = await _context.Rudiments
                .FromSqlRaw($"SELECT * FROM Rudiments WHERE Pattern LIKE '{request.Pattern}%' COLLATE SQL_Latin1_General_CP1_CS_AS")
                .ProjectTo<RudimentDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);

            return new ListResponse<RudimentDto>
            {
                Data = filterQuery
            };
        }
    }
}