using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DrumSpace.Application.Common.Exceptions;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DrumSpace.Application.Tags.Commands.DeleteTag
{
    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, SingleResponse<bool>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTagCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SingleResponse<bool>> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            SingleResponse<bool> response = new();
            
            Tag entity = await _context.Tags
                .Where(c => c.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Tag), request.Id);
            }

            _context.Tags.Remove(entity);

            response.Data = await _context.SaveChangesAsync(cancellationToken) > 0;
            return response;
        }
    }
}