using System.Threading.Tasks;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Roles.Commands.CreateRole;
using DrumSpace.Application.Roles.Commands.DeleteRole;
using DrumSpace.Application.Roles.Queries.Dtos;
using DrumSpace.Application.Roles.Queries.GetRoleDetailById;
using DrumSpace.Application.Roles.Queries.GetRolesWithPagination;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Extensions;

namespace WebAPI.Controllers
{
    public class RolesController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRoleCommand command)
        {
            SingleResponse<bool> singleResponse = await Mediator.Send(command);
            return singleResponse.ToHttpResponse();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetRolesWithPaginationQuery query)
        {
            PagedResponse<RoleDto> pagedResponse = await Mediator.Send(query);
            return pagedResponse.ToHttpResponse();
        }

        [HttpDelete("{roleId}")]
        public async Task<IActionResult> Delete(string roleId)
        {
            SingleResponse<bool> singleResponse = await Mediator.Send(new DeleteRoleCommand { RoleId = roleId });
            return singleResponse.ToHttpResponse();
        }

        // [HttpPut("{userId}")]
        // public async Task<IActionResult> Update(string userId, [FromBody] UpdateRoleCommand command)
        //
        // {
        //     if (userId != command.UserId)
        //
        //     {
        //         return BadRequest();
        //     }
        //
        //
        //     SingleResponse<bool> singleResponse = await Mediator.Send(command);
        //
        //     return singleResponse.ToHttpResponse();
        // }

        [HttpGet("detail")]
        public async Task<IActionResult> Detail(string roleId)
        {
            SingleResponse<RoleDto> singleResponse = await Mediator.Send(new GetRoleDetailByIdQuery
            {
                Id = roleId
            });

          return  singleResponse.ToHttpResponse();
        }
    }
}