using System.Threading;
using System.Threading.Tasks;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Domain.Entities;
using MediatR;
// ReSharper disable All

namespace DrumSpace.Application.CommentPosts.Commands.CreateCommentPosts
{
    public class CreateCommentPostHandler : IRequestHandler<CreateCommentPost, SingleResponse<bool>>
    {
        private readonly IApplicationDbContext _context;

        public CreateCommentPostHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SingleResponse<bool>> Handle(CreateCommentPost request, CancellationToken cancellationToken)
        {
            SingleResponse<bool> response = new();
            CommentPost entity = new() { Description = request.Description, PostId = request.PostId };
            _context.CommentPosts.Add(entity);
            int saveChangesAsync = await _context.SaveChangesAsync(cancellationToken);
            response.Data = saveChangesAsync > 0;
            return response;
        }
    }
}