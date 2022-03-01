using System.Collections.Generic;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Rudiments.Queries.Dtos;
using MediatR;

namespace DrumSpace.Application.Rudiments.Queries.GetRudimentsByType
{
    public class GetRudimentsByTypeQuery : IRequest<ListResponse<RudimentDto>>
    {
        public int Type { get; set; }
    }
}