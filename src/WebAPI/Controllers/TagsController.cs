using System.Threading.Tasks;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Tags.Commands.CreateTag;
using DrumSpace.Application.Tags.Commands.DeleteTag;
using DrumSpace.Application.Tags.Commands.UpdateTag;
using DrumSpace.Application.Tags.Queries.Dtos;
using DrumSpace.Application.Tags.Queries.GetTagsDetailById;
using DrumSpace.Application.Tags.Queries.GetTagsWithPagination;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Extensions;

namespace WebAPI.Controllers
{
    public class TagsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetTagsWithPaginationQuery query)
        {
            PagedResponse<TagDto> pagedResponse = await Mediator.Send(query);
            return pagedResponse.ToHttpResponse();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTagCommand command)
        {
            SingleResponse<int> singleResponse = await Mediator.Send(command);
            return singleResponse.ToHttpResponse();
            
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTagCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            SingleResponse<bool> singleResponse = await Mediator.Send(command);
            return singleResponse.ToHttpResponse();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            SingleResponse<bool> singleResponse = await Mediator.Send(new DeleteTagCommand { Id = id });
            return singleResponse.ToHttpResponse();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDetailById(int id)
        {
            SingleResponse<TagDto> singleResponse = await Mediator.Send(new GetTagsDetailByIdQuery
            {
                Id = id
            });
            return singleResponse.ToHttpResponse();
        }
    }
}