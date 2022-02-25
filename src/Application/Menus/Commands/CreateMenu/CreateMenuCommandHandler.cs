using System.Threading;
using System.Threading.Tasks;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Domain.Entities;
using MediatR;

namespace DrumSpace.Application.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, SingleResponse<int>>
    {
        private readonly IApplicationDbContext _context;

        public CreateMenuCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SingleResponse<int>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            SingleResponse<int> response = new();
            Menu entity = new()
            {
                Name = request.Name,
                Description = request.Description,
                Icon = request.Icon,
                Path = request.Path,
                ParentId = request.ParentId
            };

            _context.Menus.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            response.Data = entity.Id;

            return response;
        }
    }
}