using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Rudiments.Queries.Dtos;
using MediatR;

namespace DrumSpace.Application.Rudiments.Queries.GetRudimentsWithPagination
{
    public class GetRudimentsWithPaginationQuery : IRequest<PagedResponse<RudimentDto>>
    {
       public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}