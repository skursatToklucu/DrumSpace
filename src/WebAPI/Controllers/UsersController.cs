using System.Threading.Tasks;
using DrumSpace.Application.Common.Models.Response;
using DrumSpace.Application.Users.Commands.AssignUserToRole;
using DrumSpace.Application.Users.Commands.DeleteUser;
using DrumSpace.Application.Users.Commands.UpdateUser;
using DrumSpace.Application.Users.Queries.Dtos;
using DrumSpace.Application.Users.Queries.GetCurrentUserRole;
using DrumSpace.Application.Users.Queries.GetUserDetailById;
using DrumSpace.Application.Users.Queries.GetUsersWithPagination;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Extensions;

namespace WebAPI.Controllers
{
    public class UsersController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetUsersWithPaginationQuery query)
        {
            PagedResponse<UserDto> pagedResponse = await Mediator.Send(query);
            return pagedResponse.ToHttpResponse();
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> Update(string userId, [FromBody] UpdateUserCommand command)
        {
            if (userId != command.UserId)
            {
                return BadRequest();
            }

            SingleResponse<bool> singleResponse = await Mediator.Send(command);
            return singleResponse.ToHttpResponse();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(string userId)
        {
            SingleResponse<bool> singleResponse = await Mediator.Send(new DeleteUserCommand {UserId = userId});
            return singleResponse.ToHttpResponse();
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> AssignUserToRoles(string userId, [FromBody] AssignUserToRolesCommand command)
        {
            if (userId != command.UserId)
            {
                return BadRequest();
            }

            SingleResponse<bool> singleResponse = await Mediator.Send(command);
            return singleResponse.ToHttpResponse();
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Detail(string userId)
        {
            SingleResponse<UserDto> singleResponse = await Mediator.Send(new GetUserDetailByIdQuery
            {
                Id = userId
            });
            return singleResponse.ToHttpResponse();
        }

        [HttpGet("current-role")]
        public async Task<IActionResult> GetCurrentUserRole()
        {
            SingleResponse<UserWithRoleDto> singleResponse = await Mediator.Send(new GetCurrentUserRoleQuery());
            return singleResponse.ToHttpResponse();
        }
    }
}