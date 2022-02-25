using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DrumSpace.Application.Common.Exceptions;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DrumSpace.Application.Menus.Commands.DeleteMenu
{
    public class DeleteMenuCommandHandler : IRequestHandler<DeleteMenuCommand, SingleResponse<bool>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMenuCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SingleResponse<bool>> Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
        {
            SingleResponse<bool> response = new();

            Menu entity = await _context.Menus.Where(x => x.Id == request.Id).SingleOrDefaultAsync(cancellationToken);
            
            if(entity == null)  throw new NotFoundException(nameof(Menu), request.Id);

            _context.Menus.Remove(entity);

            response.Data = await _context.SaveChangesAsync(cancellationToken) > 0;
            return response;
        }
    }
}