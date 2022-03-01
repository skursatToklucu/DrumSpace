using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Rudiments.Queries.Dtos;
using DrumSpace.Application.Rudiments.Queries.GetRudimentsByType;
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

        [HttpGet("get-by-type")]
        public async Task<IActionResult> Get([FromQuery]GetRudimentsByTypeQuery query)
        {
            ListResponse<RudimentDto> listResponse = await Mediator.Send(query);
            return listResponse.ToHttpResponse();
        }
    }
}