using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DrumSpace.Application.Posts.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, SingleResponse<int>>
    {
        private readonly IApplicationDbContext _context;

        public CreatePostCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SingleResponse<int>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            SingleResponse<int> response = new();
            Post entity = new()
            {
                Title = request.Title,
                Description = request.Description,
                PostType = request.PostType
            };
            List<Tag> tags = await _context.Tags.Where(c => request.Tags.Select(x => x.Id).Contains(c.Id))
                .ToListAsync(cancellationToken);
            entity.Tags.AddRange(tags);
            _context.Posts.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);
            response.Data = entity.Id;

            return response;
        }
    }
}