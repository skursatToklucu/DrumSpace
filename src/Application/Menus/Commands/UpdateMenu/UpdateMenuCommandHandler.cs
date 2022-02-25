using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DrumSpace.Application.Common.Exceptions;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DrumSpace.Application.Menus.Commands.UpdateMenu
{
    public class UpdateMenuCommandHandler : IRequestHandler<UpdateMenuCommand, SingleResponse<bool>>
    {
        private readonly IApplicationDbContext _context;

        public UpdateMenuCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SingleResponse<bool>> Handle(UpdateMenuCommand request, CancellationToken cancellationToken)
        {
            SingleResponse<bool> response = new();

            Menu entity = await _context.Menus
                .Where(x => x.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Icon = request.Icon;
            entity.Path = request.Path;
            entity.ParentId = request.ParentId;

            response.Data = await _context.SaveChangesAsync(cancellationToken) > 0;

            return response;
        }
    }
}