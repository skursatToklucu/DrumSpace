using DrumSpace.Application.Common.Models.Response;
using MediatR;

namespace DrumSpace.Application.Tags.Commands.UpdateTag
{
    public class UpdateTagCommand : IRequest<SingleResponse<bool>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ColourHexCode { get; set; }

        public string IconPath { get; set; }
    }
}