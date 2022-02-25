using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DrumSpace.Application.Common.Exceptions;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DrumSpace.Application.Tags.Commands.UpdateTag
{
    public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, SingleResponse<bool>>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTagCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SingleResponse<bool>> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            SingleResponse<bool> response = new();

            Tag entity = await _context.Tags
                .Where(c => c.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Tag), request.Id);
            }

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.ColourHexCode = request.ColourHexCode;
            entity.IconPath = request.IconPath;

            response.Data = await _context.SaveChangesAsync(cancellationToken) > 0;

            return response;
        }
    }
}