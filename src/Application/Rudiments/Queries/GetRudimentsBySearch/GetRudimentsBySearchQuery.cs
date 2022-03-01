using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Rudiments.Queries.Dtos;
using MediatR;

namespace DrumSpace.Application.Rudiments.Queries.GetRudimentsBySearch
{
    public class GetRudimentsBySearchQuery : IRequest<ListResponse<RudimentDto>>
    {
        public string Pattern { get; set; }
    }
}