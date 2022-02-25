using System.Threading;
using System.Threading.Tasks;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Domain.Entities;
using MediatR;

namespace DrumSpace.Application.Tags.Commands.CreateTag
{
    public class CreateTagCommandHandle : IRequestHandler<CreateTagCommand, SingleResponse<int>>
    {
        private readonly IApplicationDbContext _context;

        public CreateTagCommandHandle(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SingleResponse<int>> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            SingleResponse<int> response = new();
            Tag entity = new()
            {
                Title = request.Title,
                Description = request.Description,
                ColourHexCode = request.ColourHexCode,
                IconPath = request.IconPath
            };

            _context.Tags.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);
            response.Data = entity.Id;

            return response;
        }
    }
}