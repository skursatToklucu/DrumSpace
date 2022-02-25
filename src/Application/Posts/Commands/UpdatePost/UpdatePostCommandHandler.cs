using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DrumSpace.Application.Common.Exceptions;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DrumSpace.Application.Posts.Commands.UpdatePost
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, SingleResponse<bool>>
    {
        private readonly IApplicationDbContext _context;

        public UpdatePostCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SingleResponse<bool>> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            SingleResponse<bool> response = new();

            Post entity = await _context.Posts
                .Where(c => c.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Tag), request.Id);
            }

            entity.Title = request.Title;
            entity.Description = request.Description;

            response.Data = await _context.SaveChangesAsync(cancellationToken) > 0;

            return response;
        }
    }
}