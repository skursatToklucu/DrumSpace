using System.Collections.Generic;
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

namespace DrumSpace.Application.Menus.Queries.GetMenuWithCategorization
{
    public class
        GetMenusWithCategorizationHandler : IRequestHandler<GetMenuWithCategorizationQuery,
            ListResponse<MenuCategorizeDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetMenusWithCategorizationHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ListResponse<MenuCategorizeDto>> Handle(GetMenuWithCategorizationQuery request,
            CancellationToken cancellationToken)
        {
            List<MenuDto> parentMenus = await _context.Menus.Where(x => x.ParentId == 0)
                .ProjectTo<MenuDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken: cancellationToken);

            List<MenuDto> childMenus = await _context.Menus.Where(dto => dto.ParentId != 0)
                .ProjectTo<MenuDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken: cancellationToken);
           
            var categorizeDtos = parentMenus.Select(parent => new MenuCategorizeDto
            {
                Name = parent.Name,
                Description = parent.Description,
                Icon = parent.Icon,
                Path = parent.Path,
                ParentId = parent.ParentId,
                AltMenus = childMenus.Where(x => x.ParentId == parent.Id).Select(child => new MenuCategorizeDto
                {
                    Name = child.Name,
                    Description = child.Description,
                    Icon = child.Icon,
                    Path = child.Path,
                    ParentId = child.ParentId
                }).ToList()
            }).AsEnumerable();

            return new ListResponse<MenuCategorizeDto>
            {
                Data = categorizeDtos
            };
        }
    }
}