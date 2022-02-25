using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Domain.ValueObjects;
using MediatR;

namespace DrumSpace.Application.Tags.Commands.CreateTag
{
    public class CreateTagCommand : IRequest<SingleResponse<int>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ColourHexCode { get; set; }

        public string IconPath { get; set; }
    }
}