using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Rudiments.Queries.Dtos;
using MediatR;

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

        public Task<ListResponse<RudimentDto>> Handle(GetRudimentsBySearchQuery request, CancellationToken cancellationToken)
        {
            //TODO: to be continued

            throw new NotImplementedException();
        }
    }
}