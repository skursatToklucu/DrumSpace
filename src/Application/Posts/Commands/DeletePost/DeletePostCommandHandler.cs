using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DrumSpace.Application.Common.Exceptions;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DrumSpace.Application.Posts.Commands.DeletePost
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, SingleResponse<bool>>
    {
        private readonly IApplicationDbContext _context;

        public DeletePostCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SingleResponse<bool>> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            SingleResponse<bool> response = new();

            Post entity = await _context.Posts
                .Where(c => c.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Post), request.Id);
            }

            _context.Posts.Remove(entity);

            response.Data = await _context.SaveChangesAsync(cancellationToken) > 0;
            return response;
        }
    }
}