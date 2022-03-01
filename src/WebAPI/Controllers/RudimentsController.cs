using System.Threading.Tasks;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Rudiments.Queries.Dtos;
using DrumSpace.Application.Rudiments.Queries.GetRudimentsWithPagination;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Extensions;

namespace WebAPI.Controllers
{
    public class RudimentsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetRudimentsWithPaginationQuery query)
        {
            PagedResponse<RudimentDto> pagedResponse = await Mediator.Send(query);
            return pagedResponse.ToHttpResponse();
        }
    }
}