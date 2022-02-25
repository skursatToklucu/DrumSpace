using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Tags.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DrumSpace.Application.Tags.Queries.GetTagsDetailById
{
    public class GetTagsDetailByIdQueryHandler : IRequestHandler<GetTagsDetailByIdQuery, SingleResponse<TagDto>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetTagsDetailByIdQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<SingleResponse<TagDto>> Handle(GetTagsDetailByIdQuery request, CancellationToken cancellationToken)
        {
            SingleResponse<TagDto> singleResponse = new()
            {
                Data = await _context.Tags.Where(x => x.Id == request.Id)
                    .ProjectTo<TagDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(cancellationToken)
            };
            return singleResponse;
        }
    }
}